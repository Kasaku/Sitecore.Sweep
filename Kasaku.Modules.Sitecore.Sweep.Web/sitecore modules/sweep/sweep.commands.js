// Setup Sweep.Clean command
Telerik.Web.UI.Editor.CommandList["SweepClean"] = function (commandName, editor, args) {

    //Retrieve the html selected in the editor
    var html = editor.get_html();

    jQuery.ajax({
        method: "POST",
        url: "/sitecore modules/sweep/service.asmx/Clean",
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify({ input: html })
    })
      .done(function (msg) {
          editor.set_html(msg.d);
      });

};