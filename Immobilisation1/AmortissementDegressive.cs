namespace Immobilisation1;

public class AmortissementDegressive
{
    private double _annuiteDegressive;
    private double _valeur_nette_comptable;
    private double _annuite_lineaire;
    private double _amortissement_derogatoire;

    public double AnnuiteDegressive
    {
        get => _annuiteDegressive;
        set => _annuiteDegressive = value;
    }

    public double ValeurNetteComptable
    {
        get => _valeur_nette_comptable;
        set => _valeur_nette_comptable = value;
    }

    public double AnnuiteLineaire
    {
        get => _annuite_lineaire;
        set => _annuite_lineaire = value;
    }

    public double AmortissementDerogatoire
    {
        get => _amortissement_derogatoire;
        set => _amortissement_derogatoire = value;
    }

    public AmortissementDegressive(double annuiteDegressive, double valeurNetteComptable, double annuiteLineaire, double amortissementDerogatoire)
    {
        _annuiteDegressive = annuiteDegressive;
        _valeur_nette_comptable = valeurNetteComptable;
        _annuite_lineaire = annuiteLineaire;
        _amortissement_derogatoire = amortissementDerogatoire;
    }

    public AmortissementDegressive()
    {
    }
}