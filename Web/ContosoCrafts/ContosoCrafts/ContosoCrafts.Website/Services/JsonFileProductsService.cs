namespace ContosoCrafts.Website.Services
{
    public class JsonFileProductsService
    {
        public JsonFileProductsService(IWebHostEnvironment webHostEnvironment) {
            webHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment webHostEnvironment { get; }
    }
}
