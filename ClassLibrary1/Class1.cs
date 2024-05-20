namespace ClassLibrary1
{
    public class Class1
    {
        public string demo = "The value"; 
    }

    public class Class2
    {
        public void display() {
            Class1 ob = new Class1();
            Console.WriteLine(ob.demo);
        }
    }
}