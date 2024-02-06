namespace Immobilisation1;

public class AmmortissementLineaire
{
    private int annee;
    private double annuite_d_ammortissement;
    private double ammortissement_cumule;
    private double valeur_nette_comptable;

    public int Annee
    {
        get => annee;
        set => annee = value;
    }

    public double AnnuiteDAmmortissement
    {
        get => annuite_d_ammortissement;
        set => annuite_d_ammortissement = value;
    }

    public double AmmortissementCumule
    {
        get => ammortissement_cumule;
        set => ammortissement_cumule = value;
    }

    public double ValeurNetteComptable
    {
        get => valeur_nette_comptable;
        set => valeur_nette_comptable = value;
    }

    public AmmortissementLineaire(int annee, double annuiteDAmmortissement, double ammortissementCumule, double valeurNetteComptable)
    {
        this.annee = annee;
        annuite_d_ammortissement = annuiteDAmmortissement;
        ammortissement_cumule = ammortissementCumule;
        valeur_nette_comptable = valeurNetteComptable;
    }
    
}