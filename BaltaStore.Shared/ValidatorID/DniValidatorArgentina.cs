using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaltaStore.Shared.ValidatorID
{
    public class DniValidatorArgentina
    {
        // Define a faixa mínima aceitável para um DNI válido (geralmente acima de 1 milhão)
    private const int DNI_MINIMO_ACEITAVEL = 1000000;


    public static bool IsValid(string dni)
    {
        // 1. Limpeza e Verificação de Nulo
        if (string.IsNullOrWhiteSpace(dni))
        {
            return false;
        }

        // Remove quaisquer pontos, espaços ou hífens
        string dniLimpo = new string(dni.Where(char.IsDigit).ToArray());

        // 2. Verificação de Comprimento
        // O DNI moderno tem 8 dígitos. DNIs mais antigos podem ter 7.
        if (dniLimpo.Length < 7 || dniLimpo.Length > 8)
        {
            return false;
        }

        // 3. Verificação de Dígitos (Garantir que seja um número)
        if (!long.TryParse(dniLimpo, out long dniNumero))
        {
            return false;
        }

        // 4. Verificação de Faixa
        // DNI deve ser maior que um valor mínimo razoável (evita zeros ou números muito baixos)
        if (dniNumero < DNI_MINIMO_ACEITAVEL)
        {
            return false;
        }

        // Se passar em todas as verificações de formato e faixa, consideramos válido.
        return true;
    }
    }
}