using System;

namespace DesafioProjetoHospedagem.Models
{
    /// <summary>
    /// Representa uma reserva de hospedagem.
    /// Contém informações sobre os hóspedes, suíte e dias reservados.
    /// </summary>
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        /// <summary>
        /// Cadastra a lista de hóspedes na reserva.
        /// Verifica se a quantidade de hóspedes é compatível com a capacidade da suíte.
        /// </summary>
        /// <param name="hospedes">Lista de pessoas a serem hospedadas.</param>
        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            if (Suite != null && hospedes.Count <= Suite.Capacidade)
            {
                Hospedes = hospedes;
            }
            else
            {
                throw new Exception("A suite não suporta essa quantidade de hospede!");
            }
        }

        /// <summary>
        /// Define a suíte da reserva.
        /// </summary>
        /// <param name="suite">Objeto do tipo Suite.</param>
        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        /// <summary>
        /// Retorna a quantidade atual de hóspedes na reserva.
        /// </summary>
        /// <returns>Quantidade de hóspedes cadastrados.</returns>
        public int ObterQuantidadeHospedes()
        {

            if (Hospedes != null)
            {
                return Hospedes.Count();
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Calcula o valor total da diária com base nos dias reservados e valor da suíte.
        /// Aplica 10% de desconto se forem reservados 10 dias ou mais.
        /// </summary>
        /// <returns>Valor total da hospedagem.</returns>
        public decimal CalcularValorDiaria()
        {

            decimal valor = DiasReservados * Suite.ValorDiaria;

            if (DiasReservados >= 10)
            {
                valor = valor - ((valor * 10) / 100);
            }

            return valor;
        }
    }
}