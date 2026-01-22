using Exambilet.Models.Base;

namespace Exambilet.Models
{
    public class Game :BaseEntity
    {
        public string Name { get; set; }

        public int Price { get; set; }

        public int Sale { get; set; }

        public string Image { get; set; }

    }
}
