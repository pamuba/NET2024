using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace Azure_blob_demo.Services
{
    public class ContainerService : IContainerService
    {
        private readonly BlobServiceClient _blobClient;

        public ContainerService(BlobServiceClient blobClient)
        {
            _blobClient = blobClient;
        }
        public async Task CreateContainer(string containerName)
        {
            BlobContainerClient blobContainerClient = _blobClient.GetBlobContainerClient(containerName);
            await blobContainerClient.CreateIfNotExistsAsync(PublicAccessType.BlobContainer); 
        }

        public async Task DeleteContainer(string containerName)
        {
            BlobContainerClient blobContainerClient = _blobClient.GetBlobContainerClient(containerName);
            await blobContainerClient.DeleteIfExistsAsync();
        }

        public async Task<List<string>> GetAllContainer()
        {
            List<string> containerNames = new();

            await foreach (BlobContainerItem blobContainerItem in _blobClient.GetBlobContainersAsync()) {
                containerNames.Add(blobContainerItem.Name);
            }
            return containerNames;
        }

        public async Task<List<string>> GetAllContainerAndBlobs()
        {
            List<string> containerAndBlobs = new();
            containerAndBlobs.Add("Account Name: "+ _blobClient.AccountName);
            containerAndBlobs.Add("-------------------------------------------------------------------------------");
            await foreach (BlobContainerItem blobContainerItem in _blobClient.GetBlobContainersAsync()) {
                containerAndBlobs.Add("--"+blobContainerItem.Name);

                BlobContainerClient _blobContainerClient = _blobClient.GetBlobContainerClient(blobContainerItem.Name);
                await foreach (BlobItem blobItem in _blobContainerClient.GetBlobsAsync()) {
                    //get metada
                    var bolobClient = _blobContainerClient.GetBlobClient(blobItem.Name);
                    BlobProperties blobProperties =  await bolobClient.GetPropertiesAsync();

                    string blobToAdd = blobItem.Name;
                    if (blobProperties.Metadata.ContainsKey("title")) {
                        blobToAdd += "(" + blobProperties.Metadata["title"] + ")";
                    }

                    containerAndBlobs.Add("------"+ blobToAdd);
                }
                containerAndBlobs.Add("-------------------------------------------------------------------------------");
            }
            return containerAndBlobs;

        }
    }
}
