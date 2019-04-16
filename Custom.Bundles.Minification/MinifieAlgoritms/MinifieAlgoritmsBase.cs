using System.Text;

namespace Custom.Bundles.Minification.MinifieAlgoritms
{
    /// <summary>
    /// Classe base para implementação dos métodos de Concatenação e Minificação de conteúdos de arquivos
    /// </summary>
    public abstract class MinifieAlgoritmsBase : IMinifieAlgoritms
    {
        /// <summary>
        /// Responsável pela concatenação de conteúdo já minificado
        /// </summary>
        /// <param name="fileContentSB">Referencia a um objeto StringBuilder definido em escopo acima</param>
        /// <param name="fileContent">Conteúdo do arquivo a ser minificado</param>
        /// <param name="endOption">Utilize TRUE se irá utilizar alguma regra de fechamento, ou FALSE se não usará; poderá deixar nulo, caso esta opção seja inútil</param>
        public void ConcatenateAndMinifieContent(ref StringBuilder fileContentSB, string fileContent, bool? endOption)
        {
            this.ExecuteMinification(ref fileContent, endOption);
            fileContentSB.Append(fileContent);
        }

        /// <summary>
        /// Método para execução de minificação
        /// </summary>
        /// <param name="FileContent">Conteúdo do arquivo</param>
        /// <param name="EndOption">Utilize TRUE se irá utilizar alguma regra de fechamento, ou FALSE se não usará; poderá deixar nulo, caso esta opção seja inútil</param>
        public abstract void ExecuteMinification(ref string fileContentSB, bool? endOption);
    }
}