using System;
using System.Text.RegularExpressions;

namespace Custom.Bundles.Minification.MinifieAlgoritms
{
    /// <summary>
    /// Classe especializada para execução de Minificação para arquivos JS
    /// </summary>
    public sealed class MinifieAlgoritmsJs : MinifieAlgoritmsBase
    {
        /// <summary>
        /// Método para execução de minificação
        /// </summary>
        /// <param name="fileContent">Conteúdo do arquivo JavaScript</param>
        /// <param name="endOption">Opção se será incluida o ponto e vírgula no final ou não</param>
        public override void ExecuteMinification(ref string fileContent, bool? endOption)
        {
            fileContent = Regex.Replace(fileContent, @"//(.*?)$", " ");
            fileContent = Regex.Replace(fileContent, @"\s+", " ");
            fileContent = Regex.Replace(fileContent, @"(\r\n)+", " ");
            fileContent = Regex.Replace(fileContent, @"/\*(.*?)\*/", " ");

            if (null != endOption && Convert.ToBoolean(endOption))
            {
                fileContent = fileContent + ";";
            }
        }
    }
}