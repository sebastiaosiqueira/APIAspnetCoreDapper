namespace BaltaStore.Shared.ValidatorID
{
    public class DocumentID
    {
        public DocumentID(PaisID paisid, string id)
        {
            this.paisid = paisid;
            Id = id;
        }

        public PaisID paisid { get; private set; }
        public string Id { get; private set; }
        public bool ValidarDocumento(PaisID paisid, string id)
        {
            if (paisid.Equals(null) || id == string.Empty)
                return false;
            switch (paisid)
            {

                case PaisID.Brasil:
                    CPFValidator.IsValid(id);
                    break;
                case PaisID.Argentina:
                    DniValidatorArgentina.IsValid(id);
                    break;
                case PaisID.Bolívia:
                    CiBoliviaValidator.IsValid(id);
                    break;
            }
            return true;
        }

       
    }
}
