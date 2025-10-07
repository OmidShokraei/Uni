// { nodeName } = require("jquery");

//const { type } = require("jquery");

var element;
var parent;
$(document).ready(function () {

    addEditButton("");
   

    $(document).on("click", ".eb", function () {
        element = $(this).next()[0];
        parent = $(element).closest("section")[0];
        
        $(".eoe").html($(element).attr("name"));

        var elementType = $(element).prop('nodeName');
        if (elementType == "IMG") {

            $("#ImageAlt").val($(element).attr("alt"));
            $("#ImageTitle").val($(element).attr("title"));
            $("#editImage").modal('show');
        }
        else {

            $("#eti").val($(element).text().trim().replace(/\s*[\r\n]+\s*/g, '\n')
                .replace(/(<[^\/][^>]*>)\s*/g, '$1')
                .replace(/\s*(<\/[^>]+>)/g, '$1')).select();
            $(".eoe").html($(element).attr("name"));
            $('#editText').modal('show');

        }




        //$("#eti").val($(element).text().trim()).select();
        //$('#editText').modal('show');

    });
    });

function addEditButton(a) {
    if (a == "") {
        a = `.editable`;
    }
    else {
        a = `#${a} .editable`;
    }
    $(a).before(
        `<button class="btn btn-info eb" style="z-index:999;"><i class="fa fa-edit">edit</i></button>`
    );
}
    function editText() {
        var id = $(element).attr("id");
        var content = $("#eti").val();
        $.post("/admin/editText", { id: id, content: content })
            .done(function (res) {
                if (res.status) {
                    var id2 = $(parent).attr('id').split("-");
                    $(parent).load(`/components/${id2[0]}/${id2[1]}`, function () {

                        addEditButton(`${$(parent).attr('id')}`);
                    });
                }
            })
}
function editImage() {

    var form = $("#editImage").find("form");
    var formData = new FormData(form[0]);
    formData.append("id", $(element).attr("id"));
    $.ajax({

        url: "/admin/editImage",
        type: "POST",
        data: formData,
        contentType: false,
        processData: false,
    })
        .done(function (res) {
            if (res.status) {
                var id2 = $(parent).attr('id').split("-");
                $(parent).load(`/components/${id2[0]}/${id2[1]}`, function () {

                    addEditButton(`${$(parent).attr('id')}`);
                });
            }
            else {
                swal("عملیات ناموفق", "res.m", "error");
            }
        })
        .fail(function () { })

        .always(function () { });
}