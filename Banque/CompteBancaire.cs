using System;

namespace CompteBanqueNS 
{
    public class CompteBancaire
    {
        private string m_nomClient;
        private double m_solde;
        private bool m_bloqué = false;
        private CompteBancaire()
        { }

        public CompteBancaire(String nomClient, double solde)
        {
            m_nomClient = nomClient;
            m_solde = solde;
        }
        public string nomClient
        {
            get { return m_nomClient; } 
        }
        public double Balance
        { 
            get { return m_solde; } 
        }

        public void Débiter(double montant)
        {
            if (m_bloqué)
            {
                throw new Exception("Compte bloqué");
            }
            if (montant > m_solde)
            {
                throw new ArgumentOutOfRangeException("Montant débité doit être supérieur ou égal au solde disponible");
            }
            if (montant< 0) 
            {
                throw new ApplicationException("Montant doit être positif");
            }
            m_solde -= montant; //code intentionellement faux
        }

        public void Créditer(double montant)
        {
            if (m_bloqué)
            {
                throw new Exception("Compte bloqué");
            }
            if (montant < 0)
            {
                throw new ArgumentOutOfRangeException("Montant crédité doit être supérieur à zéro");
            }
            m_solde += montant;
        }
        private void BloquerCompte()
        {
            m_bloqué = true;
        }
        private void DébloquerCompte()
        {
            m_bloqué = false;
        }
        public static void Main()
        {
            CompteBancaire cb = new CompteBancaire("Pr. Abdoulaye Dianka", 5000000);

            cb.Créditer(50000);
            cb.Débiter(400000);
            Console.WriteLine("Solde disponible égal à F{0}", cb.Balance);
        }
    }
}
