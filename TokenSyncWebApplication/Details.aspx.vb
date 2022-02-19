Public Class Details
    Inherits System.Web.UI.Page

    Private myDB As New MySqlDatabase
    Public tokenModel As New TokenViewModels.SaveViewModel

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim symbol As String = Request.QueryString("id")
        GetTokenBySymbol(symbol)
    End Sub

    ''' <summary>
    ''' retrieve token information by passing symbol
    ''' </summary>
    ''' <param name="symbol"></param>
    Private Sub GetTokenBySymbol(symbol As String)
        myDB.EstablishConnection()
        Dim records As DataRow = myDB.GetDataTable($"select * from token where symbol='{symbol}'").AsEnumerable.FirstOrDefault
        If Not records Is Nothing Then
            With records
                contractAddressData.Text = .Item("contract_address")
                priceData.Text = $"$ { .Item("price")}"
                totalSupplyData.Text = $"{ .Item("total_supply")} { .Item("symbol")} "
                totalHoldersData.Text = .Item("total_holders")
                nameData.Text = .Item("name")
            End With
        End If
        myDB.Close()
    End Sub
End Class