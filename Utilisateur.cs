namespace TorreDeBabel {
public partial class Utilisateur {
#region Propriétés
int Code;
string Nom, Prenom, Mail;
bool EstAdmin;
#endregion
#region Constructeurs
Utilisateur(string Nom, string Prenom)
{
	this.Nom = Nom;
	this.Prenom = Prenom;
	EstAdmin = false;
}
#endregion
#region Méthodes
#endregion
}
}
