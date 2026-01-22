namespace Exambilet.Areas.Admin.ViewModels.Games
{
    public class UpdateGameVM
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Price { get; set; }

        public int Sale { get; set; }

        public string? Image { get; set; }

        public IFormFile? ImageFile { get; set; }
    }
}
