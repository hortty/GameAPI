namespace GamesAPI.Model
{
    public class Game : Entity
    {
        public Game(Guid id) : base(id) { }

        public string Nome { get; set; } = String.Empty;

        public decimal Preco { get; set; }

        public string Descricao { get; set; } = String.Empty;

        public int Quantidade { get; set; }
    }
}
