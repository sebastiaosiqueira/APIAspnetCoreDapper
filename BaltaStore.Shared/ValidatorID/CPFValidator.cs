using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaltaStore.Shared.ValidatorID
{
    public static class CPFValidator
    {// O método estático principal para validação
        public static bool IsValid(string cpf)
        {
            // 1. Limpa o CPF (remove pontos e traços)
            string cpfLimpo = LimparCpf(cpf);

            // 2. Verifica o tamanho e a formação básica
            if (cpfLimpo.Length != 11 || TodosDigitosIguais(cpfLimpo))
            {
                return false;
            }

            // 3. Extrai os dígitos verificadores fornecidos
            string digitosVerificadoresFornecidos = cpfLimpo.Substring(9, 2);

            // 4. Calcula e compara o primeiro dígito verificador (V1)
            string v1 = CalcularDigitoVerificador(cpfLimpo.Substring(0, 9));
            if (v1 != digitosVerificadoresFornecidos.Substring(0, 1))
            {
                return false;
            }

            // 5. Calcula e compara o segundo dígito verificador (V2)
            // Usa os primeiros 9 dígitos mais o V1 calculado
            string v2 = CalcularDigitoVerificador(cpfLimpo.Substring(0, 10));
            if (v2 != digitosVerificadoresFornecidos.Substring(1, 1))
            {
                return false;
            }

            // 6. Se os dois dígitos baterem, o CPF é válido.
            return true;
        }

        // --- Métodos Auxiliares ---

        private static string LimparCpf(string cpf)
        {
            // Remove tudo que não for dígito
            return new string(cpf.Where(char.IsDigit).ToArray());
        }

        private static bool TodosDigitosIguais(string cpf)
        {
            // Verifica se o CPF é um número repetido (ex: "11111111111"), que é inválido.
            return cpf.All(c => c == cpf[0]);
        }

        private static string CalcularDigitoVerificador(string baseCpf)
        {
            int soma = 0;
            int peso = baseCpf.Length + 1; // O peso começa em 10 (para o primeiro dígito) ou 11 (para o segundo)

            for (int i = 0; i < baseCpf.Length; i++)
            {
                soma += int.Parse(baseCpf[i].ToString()) * peso;
                peso--;
            }

            int resto = soma % 11;

            // Regra do Módulo 11: Se o resto for 0 ou 1, o dígito é 0. Caso contrário, é 11 - resto.
            int digito = (resto < 2) ? 0 : 11 - resto;

            return digito.ToString();
        }

        //metodo DNIArgentino

    }
}