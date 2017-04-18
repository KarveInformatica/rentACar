namespace UnitTestTexto
{
    class MiTexto
    {
        private string _text;

        public MiTexto(string text)
        {
            this._text = text;
        }

        public string MiTextoPrueba(string text)
        {
            return "qe tal " + text + ", " + this._text + " te dice ola ke ase";
        }
    }
}
