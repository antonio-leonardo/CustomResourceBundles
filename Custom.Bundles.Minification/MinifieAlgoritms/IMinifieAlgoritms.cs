namespace Custom.Bundles.Minification.MinifieAlgoritms
{
   /// <summary>
    /// Interface para cuidar de abstrações dos métodos para Concatenação e Minificação de conteúdos de arquivos
    /// </summary>
    public interface IMinifieAlgoritms
    {
        /// <summary>
        /// Executará a concatenação e minificação do conteúdo dos arquivos de estilo
        /// </summary>
        /// <param name="fileContentSB">StringBuilder que terá mudança no seu estado</param>
        /// <param name="fileContent">Conteúdo a ser concatenado e minificação</param>
        /// <param name="endOption">Apenas para arquivos JavaScript, se encerrará com ponto e vírgula no final</param>
        void ConcatenateAndMinifieContent(ref System.Text.StringBuilder fileContentSB, string fileContent, bool? endOption);

        /// <summary>
        /// Executa as regras de minificação associadas à cada arquivo
        /// </summary>
        /// <param name="fileContent">Conteúdo do Arquivo</param>
        /// <param name="endOption">Apenas para arquivos JavaScript, se encerrará com ponto e vírgula no final</param>
        void ExecuteMinification(ref string fileContent, bool? endOption);
    }
}