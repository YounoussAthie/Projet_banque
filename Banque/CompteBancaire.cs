using System;

namespace CompteBanqueNS 
{
    public class CompteBancaire
    {
        private string m_nomClient;
        private double m_solde;
        private bool m_bloqu� = false;
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

        public void D�biter(double montant)
        {
            if (m_bloqu�)
            {
                throw new Exception("Compte bloqu�");
            }
            if (montant > m_solde)
            {
                throw new ArgumentOutOfRangeException("Montant d�bit� doit �tre sup�rieur ou �gal au solde disponible");
            }
            if (montant< 0) 
            {
                throw new ApplicationException("Montant doit �tre positif");
            }
            m_solde -= montant; //code intentionellement faux
        }

        public void Cr�diter(double montant)
        {
            if (m_bloqu�)
            {
                throw new Exception("Compte bloqu�");
            }
            if (montant < 0)
            {
                throw new ArgumentOutOfRangeException("Montant cr�dit� doit �tre sup�rieur � z�ro");
            }
            m_solde += montant;
        }
        private void BloquerCompte()
        {
            m_bloqu� = true;
        }
        private void D�bloquerCompte()
        {
            m_bloqu� = false;
        }
        public static void Main()
        {
            CompteBancaire cb = new CompteBancaire("Pr. Abdoulaye Dianka", 5000000);

            cb.Cr�diter(50000);
            cb.D�biter(400000);
            Console.WriteLine("Solde disponible �gal � F{0}", cb.Balance);
        }
    }
}
