namespace Immobilisation1;

public class Ammortissement
{
     private double valeur_de_base;
     private DateTime date_de_mise_en_service;
     private double durree_ammortissement;
     private double taux_ammortissement;
     private List<AmmortissementLineaire> _ammortissementLineaires;

     public List<AmmortissementLineaire> AmmortissementLineaires
     {
          get => _ammortissementLineaires;
          set => _ammortissementLineaires = value ?? throw new ArgumentNullException(nameof(value));
     }

     public double ValeurDeBase
     {
          get => valeur_de_base;
          set => valeur_de_base = value;
     }

     public DateTime DateDeMiseEnService
     {
          get => date_de_mise_en_service;
          set => date_de_mise_en_service = value;
     }

     public double DurreeAmmortissement
     {
          get => durree_ammortissement;
          set => durree_ammortissement = value;
     }

     public double TauxAmmortissement
     {
          get => taux_ammortissement;
          set => taux_ammortissement = value;
     }

     public Ammortissement(double valeurDeBase, DateTime dateDeMiseEnService, double durreeAmmortissement)
     {
          ValeurDeBase=valeurDeBase;
          DateDeMiseEnService = dateDeMiseEnService;
          DurreeAmmortissement = durreeAmmortissement;
          TauxAmmortissement = getTauxAmmortissement();
     }

     public Ammortissement()
     {
     }

     public double getTauxAmmortissement()
     {
          return 100 / DurreeAmmortissement;
     }

     public double getFirstAnnuite(double valeurNetteComptable)
     {
          double nombreJours = CalculerJoursRestantsDansAnnee(DateDeMiseEnService);
          return valeurNetteComptable * (nombreJours/360) * (TauxAmmortissement / 100) ;
     }

     public double getLastAnnuite(double valeurnetteComptable)
     {
          double nombreJours = calculerNombreJoursDepuisDebutExercice(DateDeMiseEnService);
          return valeurnetteComptable * (nombreJours/360) * (TauxAmmortissement / 100) ;

     }

     public double getSimpleAnnuite()
     {
          return ValeurDeBase / DurreeAmmortissement;
     }
     public static int CalculerJoursRestantsDansAnnee(DateTime date)
     {
          // obtenir la fin de l'annee
          DateTime dateActuelle=DateTime.Now;
          DateTime finAnnee = new DateTime(dateActuelle.Year, 12, 31);
          int exes = (finAnnee.Month - date.Month + 1) / 2;
          return ((int)(finAnnee - date).TotalDays)-exes;
     }

     public static int calculerNombreJoursDepuisDebutExercice(DateTime date)
     {
          // supposons que le début de l'exercice soit le debut de l'annee amzay tsy manahirana 
          DateTime dateActuelle= DateTime.Now;
          DateTime dateDebutAnnee = new DateTime(dateActuelle.Year, 01, 01);
          int exes = (date.Month - dateActuelle.Month + 1) / 2;
          Console.WriteLine("debut annee : "+dateDebutAnnee);
          return ((int)((date.Month - dateActuelle.Month)+1))*30;
     }
     
     // fonction pour l'ammortissement lineaire 
     public List<AmmortissementLineaire> calculAmmortissementLineaire()
     {
          List<AmmortissementLineaire> ammortissementLineaires = new List<AmmortissementLineaire>();
          double VNC = ValeurDeBase;
          // etape 1 : calculer-na aloha ny etat initiale an'le ammortissement 
          double annuite = getFirstAnnuite(VNC);
          double ammortissementCumule = annuite;
          int annee = 0;
          VNC -= annuite;
          AmmortissementLineaire ammortissementLineaire =
               new AmmortissementLineaire(annee, annuite, ammortissementCumule, VNC);
          ammortissementLineaires.Add(ammortissementLineaire);
          for (int i = 1; i < DurreeAmmortissement; i++)
          {
               annuite = getSimpleAnnuite();
               ammortissementCumule += annuite;
               VNC -= annuite;
               ammortissementLineaire =
                    new AmmortissementLineaire(annee, annuite, ammortissementCumule, VNC);
               ammortissementLineaires.Add(ammortissementLineaire);
          }
          // dernier ammortissement 
          annuite = getLastAnnuite(ValeurDeBase);
          ammortissementCumule += annuite;
          Console.WriteLine(annuite);
          VNC -= annuite;
          ammortissementLineaire =
               new AmmortissementLineaire(annee, annuite, ammortissementCumule, VNC);
          ammortissementLineaires.Add(ammortissementLineaire);
          return ammortissementLineaires;
     }
     // ===== amortissement dégressif

     public double getCoefficientDegressif()
     {
          if (DurreeAmmortissement >= 3 && DurreeAmmortissement <= 4)
          {
               return 1.25;
          }
          else if (DurreeAmmortissement >= 5 && DurreeAmmortissement <= 6)
          {
               return 1.75;
          }else if (DurreeAmmortissement > 6)
          {
               return 2.25;
          }
          else
          {
               return 1;
          }
     }
     

     public double getTauxAmortissementDegressif()
     {
          return (1 / DurreeAmmortissement)*getCoefficientDegressif();
     }

     public double getTemps()
     {
          double mois = 12-DateDeMiseEnService.Month+1;
          Console.WriteLine("+"+ (12 - (mois )));
          return mois / 12;
     }

     public double getAnuiteDegressiveFirstYear(double VNC)
     {
          return VNC * getTauxAmortissementDegressif();
     }

     public List<AmortissementDegressive> calculAmortissementDegressives()
     {
          // etape 1 
          List<AmortissementDegressive> amortissementDegressives = new List<AmortissementDegressive>();
          AmortissementDegressive amortissementDegressive = new AmortissementDegressive();
          double VNC= ValeurDeBase;
          double anuiteDegressive = VNC
                                    * (double)((int)(getTauxAmortissementDegressif() * 100))/100
                                    * getTemps();
          Console.WriteLine("temps : "+ VNC+" | "+ 9.0/12.0);
          double annuiteLineaire = getFirstAnnuite(VNC);
          double amortissementDerogatoire = anuiteDegressive - annuiteLineaire;
          VNC -= anuiteDegressive;
          amortissementDegressive.ValeurNetteComptable = VNC;
          amortissementDegressive.AnnuiteDegressive = anuiteDegressive;
          amortissementDegressive.AnnuiteLineaire = annuiteLineaire;
          amortissementDegressive.AmortissementDerogatoire = amortissementDerogatoire;
          amortissementDegressives.Add(amortissementDegressive);
          for (int i = 1; i < DurreeAmmortissement-2; i++)
          {
               Console.WriteLine(DurreeAmmortissement-2);
               anuiteDegressive = Math.Ceiling(VNC * getTauxAmortissementDegressif());
               annuiteLineaire = getSimpleAnnuite();
               amortissementDerogatoire = anuiteDegressive - annuiteLineaire;
               VNC -= anuiteDegressive;
               amortissementDegressive = new AmortissementDegressive();
               amortissementDegressive.ValeurNetteComptable = VNC;
               amortissementDegressive.AnnuiteDegressive = anuiteDegressive;
               amortissementDegressive.AnnuiteLineaire = annuiteLineaire;
               amortissementDegressive.AmortissementDerogatoire = amortissementDerogatoire;
               amortissementDegressives.Add(amortissementDegressive);
               Console.WriteLine("vnc :"+VNC);
          }
          // //annee -3
          // Console.WriteLine("vnc/2 : "+VNC/2+"vnc :"+VNC);
          anuiteDegressive = VNC/2;
          annuiteLineaire = getSimpleAnnuite();
          amortissementDerogatoire = anuiteDegressive - annuiteLineaire;
          VNC -= anuiteDegressive;
          amortissementDegressive = new AmortissementDegressive();
          amortissementDegressive.ValeurNetteComptable = VNC;
          amortissementDegressive.AnnuiteDegressive = anuiteDegressive;
          amortissementDegressive.AnnuiteLineaire = annuiteLineaire;
          amortissementDegressive.AmortissementDerogatoire = amortissementDerogatoire;
          amortissementDegressives.Add(amortissementDegressive);
          // // annee -2 
          // // anuiteDegressive = VNC* getTauxAmortissementDegressif();
          annuiteLineaire = getSimpleAnnuite();
          amortissementDerogatoire = anuiteDegressive - annuiteLineaire;
          VNC -= anuiteDegressive;
          amortissementDegressive = new AmortissementDegressive();
          amortissementDegressive.ValeurNetteComptable = VNC;
          amortissementDegressive.AnnuiteDegressive = anuiteDegressive;
          amortissementDegressive.AnnuiteLineaire = annuiteLineaire;
          amortissementDegressive.AmortissementDerogatoire = amortissementDerogatoire;
          amortissementDegressives.Add(amortissementDegressive);
          // // annee -1
          if (VNC == 0)
          {
               anuiteDegressive = 0;
               annuiteLineaire = getLastAnnuite(ValeurDeBase);
               amortissementDerogatoire = anuiteDegressive - annuiteLineaire;
               VNC -= anuiteDegressive;
               amortissementDegressive = new AmortissementDegressive();
               amortissementDegressive.ValeurNetteComptable = VNC;
               amortissementDegressive.AnnuiteDegressive = anuiteDegressive;
               amortissementDegressive.AnnuiteLineaire = annuiteLineaire;
               amortissementDegressive.AmortissementDerogatoire = amortissementDerogatoire;
               amortissementDegressives.Add(amortissementDegressive);
          }
          

          return amortissementDegressives;
     }
}