Public Class _Default
    Inherits Page

    Public tokenModel As New TokenViewModels.SaveViewModel
    Private myDB As New MySqlDatabase
    Private pieChartJson As String

#Region "EventList"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.BindGrid()
            Me.BindPieChart()
        End If
    End Sub

    ''' <summary>
    ''' On page index change
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub OnPageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        GridView1.PageIndex = e.NewPageIndex
        Me.BindGrid()
    End Sub

    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        If e.CommandName = "EditToken" Then
            GettokenBySymbol(e.CommandArgument)
        End If
    End Sub

    ''' <summary>
    ''' Reset all input string
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub Reset(sender As Object, e As EventArgs) Handles btnReset.Click
        ResettoEmtpy()
    End Sub

    ''' <summary>
    ''' Update/Create new information
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub UpdateRecords(sender As Object, e As EventArgs) Handles btnSave.Click
        'to confirm the input is valid
        With tokenModel
            tokenModel.Name = txtName.Text
            tokenModel.Symbol = txtSymbol.Text
            tokenModel.ContractAddress = txtContractAddress.Text
            tokenModel.TotalSupply = txtTotalSupply.Text
            tokenModel.TotalHolders = txtTotalHolders.Text
        End With

        myDB.EstablishConnection()
        Dim sql As String
        If txtSymbol.Text.Length > 0 Then
            If myDB.CheckIfExist($"select * from token where symbol ='{txtSymbol.Text}'") Then
                'Update existing records
                sql = $"update token set name = '{tokenModel.Name}', total_supply = {tokenModel.TotalSupply}, contract_address='{tokenModel.ContractAddress}', total_holders={tokenModel.TotalHolders} where symbol = '{tokenModel.Symbol}'"
                myDB.ExecuteQuery(sql)
            Else
                'create new
                sql = $"INSERT INTO `tokendb`.`token`(`symbol`,`name`,`total_supply`,`contract_address`,`total_holders`,`price`) VALUES('{tokenModel.Symbol}','{tokenModel.Name}',{tokenModel.TotalSupply},'{tokenModel.ContractAddress}',{tokenModel.TotalHolders},0.00);"
                myDB.ExecuteQuery(sql)
            End If
            Me.BindGrid()
            Me.ResettoEmtpy()
        End If
    End Sub


    ''' <summary>
    ''' Export result to CSV
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub ExporttoCSV(sender As Object, e As EventArgs) Handles btnExport.Click
        ExportGridToCSV()
    End Sub

#End Region
    Private Sub ExportGridToCSV()
        Response.Clear()
        Response.Buffer = True
        Response.AddHeader("content-disposition", $"attachment;filename=GridViewExport_{DateTime.Now}.csv")
        Response.Charset = ""
        Response.ContentType = "text/csv"
        GridView1.AllowPaging = False
        Me.BindGrid()
        Dim sb As StringBuilder = New StringBuilder()

        For Each cell As TableCell In GridView1.HeaderRow.Cells
            'Append data with separator.
            sb.Append(cell.Text & ",")
        Next

        'Append new line character.
        sb.Append(vbCr & vbLf)

        For Each row As GridViewRow In GridView1.Rows
            For Each cell As TableCell In row.Cells
                'Append data with separator.
                sb.Append(cell.Text & ",")
            Next
            'Append new line character.
            sb.Append(vbCr & vbLf)
        Next

        Response.Output.Write(sb.ToString())
        Response.Flush()
        Response.End()
    End Sub

    Private Sub GettokenBySymbol(symbol As String)

        myDB.EstablishConnection()
        Dim records As DataRow = myDB.GetDataTable($"select * from token where symbol='{symbol}'").AsEnumerable.FirstOrDefault
        If Not records Is Nothing Then
            With records
                txtName.Text = .Item("name")
                txtSymbol.Text = .Item("symbol")
                txtContractAddress.Text = .Item("contract_address")
                txtTotalSupply.Text = .Item("total_supply")
                txtTotalHolders.Text = .Item("total_holders")
            End With
        End If
        myDB.Close()
    End Sub


    ''' <summary>
    ''' Reset the input string to empty
    ''' </summary>
    Private Sub ResettoEmtpy()
        txtName.Text = String.Empty
        txtSymbol.Text = String.Empty
        txtContractAddress.Text = String.Empty
        txtTotalSupply.Text = String.Empty
        txtTotalHolders.Text = String.Empty
    End Sub

    ''' <summary>
    ''' Retrieve token information from database
    ''' </summary>
    Private Sub BindGrid()
        myDB.EstablishConnection()
        Dim tokenDt As New DataTable
        'tokenView that contain the fields total supply percentage
        tokenDt = myDB.GetDataTable($"select * from TokenView")
        GridView1.DataSource = tokenDt
        GridView1.DataBind()
        GridView1.UseAccessibleHeader = True
        GridView1.HeaderRow.TableSection = TableRowSection.TableHeader
    End Sub

    ''' <summary>
    ''' Retrieve token information from database for PieChart
    ''' </summary>
    Private Sub BindPieChart()
        pieChartJson = ("[")

        myDB.EstablishConnection()
        Dim tokenDt As New DataTable
        'tokenView that contain the fields total supply percentage
        tokenDt = myDB.GetDataTable($"select * from TokenView")
        For Each records As DataRow In tokenDt.AsEnumerable
            Dim result As New TokenViewModels.PieChartView
            With records
                result.Name = .Item("symbol")
                result.Y = Decimal.Parse(.Item("totalpercent").ToString.Replace("%", ""))
                pieChartJson = $"{pieChartJson}{{name:""{ result.Name}"",y:{result.Y}}},"
            End With
        Next
        pieChartJson = pieChartJson.Remove(pieChartJson.Length - 1) & "]"
        myDB.Close()
    End Sub


End Class