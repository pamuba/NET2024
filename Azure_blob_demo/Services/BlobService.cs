using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Sas;
using Azure_blob_demo.Models;

namespace Azure_blob_demo.Services
{
    public class BlobService : IBlobService
    {
        private readonly BlobServiceClient _blobClient;

        public BlobService(BlobServiceClient blobClient)
        {
            _blobClient = blobClient;
        }
        public async Task<bool> DeleteBlob(string name, string containerName)
        {
            BlobContainerClient blobContainerClient = _blobClient.GetBlobContainerClient(containerName);
            var blobClient = blobContainerClient.GetBlobClient(name);

            return await blobClient.DeleteIfExistsAsync();
        }

        public async Task<List<string>> GetAllBlobs(string containerName)
        {
            BlobContainerClient blobContainerClient = _blobClient.GetBlobContainerClient(containerName);
            var blobs = blobContainerClient.GetBlobsAsync();

            var blobString = new List<string>();
            await foreach (var item in blobs) {
                blobString.Add(item.Name);
            }
            return blobString;
        }

        public async Task<List<Blob>> GetAllBlobsWithUri(string containerName)
        {
            BlobContainerClient blobContainerClient = _blobClient.GetBlobContainerClient(containerName);
            var blobs = blobContainerClient.GetBlobsAsync();
            var blobList = new List<Blob>();
            string sasConfigurationSignature = "";

            //if (blobContainerClient.CanGenerateSasUri)
            //{
            //    BlobSasBuilder sasBuilder = new BlobSasBuilder()
            //    {
            //        BlobContainerName = blobContainerClient.Name,
            //        Resource = "c",
            //        StartsOn = DateTimeOffset.UtcNow,
            //        ExpiresOn = DateTimeOffset.UtcNow.AddMinutes(1),
            //        CacheControl = "max-age=" + DateTimeOffset.UtcNow.AddMinutes(1)
            //    };
            //    sasBuilder.SetPermissions(BlobSasPermissions.Read | BlobSasPermissions.Write);
            //    //store the token parht but not the Uri for the container
            //    sasConfigurationSignature = blobContainerClient.GenerateSasUri(sasBuilder).AbsoluteUri.Split('?')[1].ToString();
            //}


            await foreach (var item in blobs)
            {
                var blobClient = blobContainerClient.GetBlobClient(item.Name);
                Blob blobIndividual = new() {
                    Uri = blobClient.Uri.AbsoluteUri //+ "?" + sasConfigurationSignature
                };

                //if (blobClient.CanGenerateSasUri)
                //{
                //    BlobSasBuilder sasBuilder = new BlobSasBuilder()
                //    {
                //        BlobContainerName = blobClient.GetParentBlobContainerClient().Name,
                //        BlobName = blobClient.Name,
                //        Resource = "b",
                //        StartsOn = DateTimeOffset.UtcNow,
                //        ExpiresOn = DateTimeOffset.UtcNow.AddSeconds(20),
                //        CacheControl = "max-age=" + DateTimeOffset.UtcNow.AddSeconds(20)
                //        //ExpiresOn = DateTime.Now.AddMinutes(1)
                //    };
                //    sasBuilder.SetPermissions(BlobSasPermissions.Read | BlobSasPermissions.Write);
                //    blobIndividual.Uri = blobClient.GenerateSasUri(sasBuilder).AbsoluteUri;
                //}


                BlobProperties blobProperties = await blobClient.GetPropertiesAsync();

                if (blobProperties.Metadata.ContainsKey("title")) { 
                    blobIndividual.Title = blobProperties.Metadata["title"];
                }
                if (blobProperties.Metadata.ContainsKey("comment"))
                {
                    blobIndividual.Comment = blobProperties.Metadata["comment"];
                }
                blobList.Add(blobIndividual);
            }
            return blobList;
        }

        public async Task<string> GetBlob(string name, string containerName)
        {
            BlobContainerClient blobContainerClient = _blobClient.GetBlobContainerClient(containerName);
            var blobClient = blobContainerClient.GetBlobClient(name);
            return blobClient.Uri.AbsoluteUri;
        }

        public async Task<bool> UploadBlob(string name, IFormFile file, string containerName, Blob blob)
        {
            BlobContainerClient blobContainerClient = _blobClient.GetBlobContainerClient(containerName);
            var blobClient = blobContainerClient.GetBlobClient(name);

            var httpHeaders = new BlobHttpHeaders()
            {
                ContentType = file.ContentType
            };

            IDictionary<string, string> metadata = new Dictionary<string, string>();
            metadata.Add("title", blob.Title);
            metadata["comment"] = blob.Comment;

            var result = await blobClient.UploadAsync(file.OpenReadStream(), httpHeaders, metadata);

            //IDictionary<string, string> removeMetadata = new Dictionary<string, string>();
            //await blobClient.SetMetadataAsync(removeMetadata);

            metadata.Remove("title");
            await blobClient.SetMetadataAsync(metadata);

            if (result != null) {
                return true;
            }
            return false;
        }
    }
}
