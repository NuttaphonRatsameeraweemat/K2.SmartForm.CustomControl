// The Ajax Handler can now be used on the client side, for example, by using a jQuery function.
// The javascript example below will simply call the Ajax handler.

// Using the AJAX Handler
(function ($, undefined) {
    $(document).ready(function () {
        alert("ABC");
        // Use event delegation
        //$(document).delegate('.SFC.CustomControl-HelloWorldControl', 'click.HelloWorldExample1', function (e) {
        //    var target = this;

        //    $.ajax({
        //        url: 'HelloWorld.handler',
        //        cache: false,
        //        dataType: 'text'
        //    }).done(function (text) {
        //        target.innerHTML = text;
        //        alert(text);
        //    });
        //});
        $("#btn1").click(function () { Test(); });
    });
    function Test() {
        var docDefinition = {
            content: [
                'Check out our nice column example:\n', // first this line
                {
                    alignment: 'justify', // then two justified columns of text
                    columns: [
                        {
                            text: 'Some cool text for first column goes here.'
                        },
                        {
                            text: 'Some cool text for second column goes here.'
                        }
                    ]
                }
            ]
        };

        pdfMake.createPdf(docDefinition).open();
    }
})(jQuery);