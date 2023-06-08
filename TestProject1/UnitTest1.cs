using PresentationLayer.Presenters;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var user = new DummyUser();
            var presenter = new Presenter(user);

        }
    }

    class DummyUser
    {
        //--

        public string? Album_Title { get; set; }
        public string? Artist { get; set; }
        public string? Year { get; set; }
        public string? Image_URL { get; set; }
        public string? Description { get; set; }
    }
}

