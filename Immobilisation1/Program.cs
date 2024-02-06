// See https://aka.ms/new-console-template for more information

using Immobilisation1;

Console.WriteLine("Hello, World!");

Ammortissement ammortissement= new Ammortissement(8000, DateTime.Parse("2024-07-1"), 5);
// ammortissement.TauxAmmortissement = 20;
// Console.WriteLine(ammortissement.TauxAmmortissement);
//
// Console.WriteLine(Ammortissement.calculerNombreJoursDepuisDebutExercice(ammortissement.DateDeMiseEnService));
// Console.WriteLine("annuite");
// // Console.WriteLine(ammortissement.(ammortissement.ValeurDeBase));
//
// Console.WriteLine("simple annuite : "+ammortissement.getSimpleAnnuite());
//
// Console.WriteLine((DateTime.Parse("2024-07-01") - DateTime.Parse("2024-01-01")).TotalDays);

foreach (var ammortissementLineaire in ammortissement.calculAmmortissementLineaire())
{
    Console.WriteLine("annuite : "+ammortissementLineaire.AnnuiteDAmmortissement+" amm cummule :  "+ammortissementLineaire.AmmortissementCumule+" VNC : "+ammortissementLineaire.ValeurNetteComptable);
}
 ammortissement= new Ammortissement(20000, DateTime.Parse("2024-04-1"), 5);


foreach (var ammortissementDegressive in ammortissement.calculAmortissementDegressives())
{
    Console.WriteLine("annuite D : "+ammortissementDegressive.AnnuiteDegressive+" Ann lin :  "+ammortissementDegressive.AnnuiteLineaire+" VNC : "+ammortissementDegressive.ValeurNetteComptable+" derog : "+ammortissementDegressive.AmortissementDerogatoire);
}