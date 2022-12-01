namespace Helpers.GlobalEntities
{
    public enum ApiStatusCode
    {
        LoginError = -200,
        TransactionError = -1,
        TransactionSuccess = 1,
        InternalServerError = 500,
        ErrorInActions = 400
    }
}
