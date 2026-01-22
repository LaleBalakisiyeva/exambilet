using Microsoft.AspNetCore.Http;

namespace Exambilet.Areas.Admin.ViewModels.Games
{
    public class CreateGameVM
    {
        public string Name { get; set; }

        public int Price { get; set; }

        public int Sale { get; set; }

        public IFormFile ImageFile { get; set; }
    }
}
