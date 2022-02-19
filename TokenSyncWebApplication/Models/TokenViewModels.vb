Imports System.ComponentModel.DataAnnotations
Public Class TokenViewModels
    Public Class SaveViewModel
        Private _TotalSupply As Integer
        Private _TotalHolders As Integer
        <Required>
        <Display(Name:="Name")>
        Public Property Name As String

        <Required>
        <StringLength(100, ErrorMessage:="The {0} must be at least {3} characters long.", MinimumLength:=3)>
        <Display(Name:="Symbol")>
        Public Property Symbol As String

        <Required>
        <Display(Name:="Contract Address")>
        Public Property ContractAddress As String

        <Required>
        <Display(Name:="Total Supply")>
        Public Property TotalSupply As Integer
            Get
                Return _TotalSupply
            End Get
            Set
                _TotalSupply = Integer.Parse(Value)
            End Set
        End Property

        <Required>
        <Display(Name:="Total Holders")>
        Public Property TotalHolders As Integer
            Get
                Return _TotalHolders
            End Get
            Set
                _TotalHolders = Integer.Parse(Value)
            End Set
        End Property
    End Class

    Public Class PieChartView
        Public Property Name As String
        Public Property Y As Decimal
    End Class
End Class
