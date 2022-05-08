<%@ Application Language="VB" %>
<%@ Import Namespace="Serilog" %>
<%@ Import Namespace="Serilog.Events" %>
<%@ Import Namespace="SerilogWeb.Classic" %>
<%@ Import Namespace="Serilog.Sinks.Elasticsearch" %>
<%@ Import Namespace="System.Web.Configuration" %>

<script RunAt="server">
    Const outputTemplate = "[{Timestamp:yyyy-MM-dd HH:mm:ss} {ClientIp} {Level:u3}] {Message:lj}{NewLine}{Exception:lj}{NewLine}{FormData:lj}"

    Function SerilogWebClassicConfig(cfg As SerilogWebClassicConfigurationBuilder) As SerilogWebClassicConfigurationBuilder
        Return cfg.EnableFormDataLogging(AddressOf FormDataLoggingConfig)
    End Function

    Sub FormDataLoggingConfig(form As SerilogWebClassicConfigurationBuilder.FormDataLoggingConfigurationBuilder)
        form.AtLevel(LogEventLevel.Information)
    End Sub

    Function ConfigureElasticSink() As ElasticsearchSinkOptions
        Dim options = New ElasticsearchSinkOptions(New Uri(WebConfigurationManager.AppSettings("ElasticUrl")))
        options.AutoRegisterTemplate = True
        options.IndexFormat = String.Format(WebConfigurationManager.AppSettings("ElasticIndexFormat"), DateTime.UtcNow)

        Return options
    End Function

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs on application startup               
        SerilogWebClassic.Configure(AddressOf SerilogWebClassicConfig)

        Log.Logger = New Serilog.LoggerConfiguration().MinimumLevel.Information().WriteTo.Debug(outputTemplate:=outputTemplate).WriteTo.Elasticsearch(ConfigureElasticSink()).Enrich.WithClientIp().CreateLogger()
    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs on application shutdown
    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when an unhandled error occurs
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when a new session is started
        Session("Authenticated") = False
        Session("Username") = ""
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when a session ends. 
        ' Note: The Session_End event is raised only when the sessionstate mode
        ' is set to InProc in the Web.config file. If session mode is set to StateServer 
        ' or SQLServer, the event is not raised.
    End Sub

</script>
