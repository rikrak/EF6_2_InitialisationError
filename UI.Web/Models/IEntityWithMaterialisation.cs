namespace UI.Web.Models
{
    public interface IEntityWithMaterialisation
    {
        /// <summary>
        /// Called after the entity has been loaded from the repository
        /// </summary>
        void OnMaterlialisation();
    }
}