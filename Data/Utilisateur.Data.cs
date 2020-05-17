using System;
using System.Data;

namespace TorreDeBabel {
partial class Utilisateur {
#region Méthodes
static Utilisateur
FromData(DataRow dr)
{
	Utilisateur u;

	try {
		u = new Utilisateur(
			dr["nomUtil"].ToString(),
			dr["pnUtil"].ToString()
		);
	} catch (ArgumentException e) {
		// TODO
		u = null;
	}
	return u;
}

/// <summary>
/// Inscrit un nouvel utilisateur dans une table locale.
/// </summary>
/// <param name="dt">la table locale contenant les utilisateurs</param>
/// <param name="u">l'utilisateur à ajouter</param>
/// <returns>si l'opération a réussi</returns>
static bool
Inscrire(DataTable dt, Utilisateur u)
{
	// TODO implement
	return false;
}
#endregion
}
}
