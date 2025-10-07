using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaltaStore.Shared.ValidatorID
{
    public static class CiBoliviaValidator
    {
        // Define o comprimento mínimo e máximo razoável para o número de C.I.
    private const int CI_MIN_LENGTH = 7;
    private const int CI_MAX_LENGTH = 10;
    
    // O valor mínimo aceitável para um C.I. (Geralmente acima de 1 milhão)
    private const long CI_MINIMO_ACEITAVEL = 1000000;

    /// <summary>
    /// Valida a estrutura e o formato do Cédula de Identidad (C.I.) boliviano.
    /// </summary>
    /// <param name="ci">A string contendo o número do C.I., opcionalmente com sufixo (ex: 7890123 LP).</param>
    /// <returns>True se o C.I. estiver no formato e faixa esperados, caso contrário False.</returns>
    public static bool IsValid(string ci)
    {
        if (string.IsNullOrWhiteSpace(ci))
        {
            return false;
        }

        // 1. Limpeza: Remove pontos, traços e letras/espaços no final (ex: " LP", " SC")
        // Foca apenas nos dígitos numéricos iniciais.
        string ciLimpo = new string(ci.TakeWhile(char.IsDigit).ToArray());

        // 2. Verificação de Comprimento
        if (ciLimpo.Length < CI_MIN_LENGTH || ciLimpo.Length > CI_MAX_LENGTH)
        {
            return false;
        }

        // 3. Verificação de Dígitos
        // Tenta converter o número limpo para um tipo numérico (long, para garantir que caiba).
        if (!long.TryParse(ciLimpo, out long ciNumero))
        {
            // Isso não deve ocorrer se o TakeWhile(char.IsDigit) funcionar corretamente, 
            // mas é um bom check de segurança.
            return false;
        }

        // 4. Verificação de Faixa
        // Garante que o número não seja trivial (como 0 ou 1)
        if (ciNumero < CI_MINIMO_ACEITAVEL)
        {
            return false;
        }

        // Se passar em todas as verificações de formato e faixa, consideramos a estrutura válida.
        return true;
    }
        
    }
}