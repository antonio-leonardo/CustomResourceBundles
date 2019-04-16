using System.Text.RegularExpressions;

namespace Custom.Bundles.Minification.MinifieAlgoritms
{
    /// <summary>
    /// Classe especializada para execução de Minificação para arquivos CSS
    /// </summary>
    public sealed class MinifieAlgoritmsCss : MinifieAlgoritmsBase
    {
        /// <summary>
        /// Método para execução de minificação
        /// </summary>
        /// <param name="fileContent">Conteúdo do arquivo JavaScript</param>
        /// <param name="endOption">Argumento inutilizado nesta especialização</param>
        public override void ExecuteMinification(ref string fileContent, bool? endOption)
        {
            fileContent = Regex.Replace(fileContent, @"[a-zA-Z]+#", "#");
            fileContent = Regex.Replace(fileContent, @"[\n\r]+\s*", string.Empty);
            fileContent = Regex.Replace(fileContent, @"\s+", " ");
            fileContent = Regex.Replace(fileContent, @"\s?([:,;{}])\s?", "$1");
            fileContent = fileContent.Replace(";}", "}");
            fileContent = Regex.Replace(fileContent, @"([\s:]0)(px|pt|%|em)", "$1");

            //Remove comments from CSS
            fileContent = Regex.Replace(fileContent, @"/\*[\d\D]*?\*/", string.Empty);
        }
    }
}