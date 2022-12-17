using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CompteBanqueNS;

namespace BanqueTests
{
    [TestClass]
    public class CompteBancaireTests
    {
        [TestMethod]
        public void VérifierDébiterCompteCorrecr()
        {
            double soldeInitial = 500000;
            double montantDébit = 400000;
            double soldeAttendu = 100000;
            var compte = new CompteBancaire("Pr. Abdoulaye Diankha", soldeInitial);

            // Débiter 
            compte.Débiter(montantDébit);

            // Tester 
            double soldeObtenu = compte.Balance;
            Assert.AreEqual(soldeAttendu, soldeObtenu, 0.001, "Compte débité incorrectement");
        }

        [TestMethod]
        [ExpectedExceptionAttribute(ArgumentOutOfRangeException, "Tout s'est bien passé !")]
        public void DébiterMontantSupérieurSoldeLèveArgumentOutOfRange (ArgumentOutOfRangeException argumentOutOfRangeException)
        {
            double soldeInitial = 500000;
            double montantDébit = 700000;

            var compte = new CompteBancaire("Pr. Abdoulaye Diankha", soldeInitial);

            // Débiter et tester 
            compte.Débiter(montantDébit);
        }

        [TestMethod]
        [ExpectedExceptionAttribute(ArgumentOutOfRangeException, "Tout s'est bien passé !")]
        public void DébiterMontantNégatifLèveArgumentOutOfRange ()
        {
            double soldeInitial = 500000;
            double montantDébit = -10000;
            var compte = new CompteBancaire("Pr. Abdoulaye Diankha", soldeInitial);

            // Débiter et tester 
            compte.Débiter(montantDébit);
        }
    }
}
