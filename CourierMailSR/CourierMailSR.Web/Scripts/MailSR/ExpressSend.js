$(function () {

    var getFilterValues = function () {
        var result = {};
        result["search"] = $("input[name='searchCondition']").val();
        return result;
    };

    var expressInfoTable = $('#expressSendListtables').dataTable({
        "processing": true,
        "serverSide": true,
        bFilter: false,
        ajax: {
            url: "/MailSR/GetMailSendList",
            type: 'POST',
            data: function (d) {
                return $.extend({}, d, getFilterValues());
            }
        }, columnDefs: [
            { targets: '_all', sortable: false }
        ],
        columns: [{
            "data": "ExpressNo",
            className: "text-left",
            width: '100px',
            render: function (data, type, row, meta) {
                return data;
            }
        },
        {
            "data": "Name",
            className: "text-left",
            width: 'auto',
            render: function (data, type, row, meta) {

                return data;
            }
        },
        {
            "data": "Phone",
            className: "text-left",
            width: 'auto',
            render: function (data, type, row, meta) {

                return data;
            }
        }
            ,
        {
            "data": "ReceiveTime",
            className: "text-left",
            width: 'auto',
            render: function (data, type, row, meta) {

                return data;
            }
        }
            ,
        {
            "data": "SendTime",
            className: "text-left",
            width: 'auto',
            render: function (data, type, row, meta) {

                return data;
            }
        }
            
            ,
        {
            "data": "Status",
            className: "text-left",
            width: 'auto',
            render: function (data, type, row, meta) {

                return data;
            }
        }
            ,
        {
            "data": "Id",
            className: "text-left",
            width: 'auto',
            render: function (data, type, row, meta) {

                return "<button data-id='" + data + "' class='btn btn-sm btn-danger btn-sendExpress '>send</button>"
            }
        },

        ]
    });

    expressInfoTable.on("click", ".btn-sendExpress", function () {

       
        var id = parseInt($(this).data("id"));

        $.ajax({
            url: "/MailSR/SendExpress",
            type: 'POST',
            data: { id: id }
        }).done(function () {

         
            expressInfoTable.DataTable().ajax.reload();
        }).fail(function () {

        });


    });


    initBtns(expressInfoTable);


});

function validInput() {

    if ($("input[name='ExpressNo']").val() == "" || $("input[name='Name']").val() == "" || $("input[name='Phone']").val() == "") {
        return false;
    }

    return true;
}


function initBtns(expressInfoTable) {

    $("button.btn-searchSendExpressInfo").click(function () {
        expressInfoTable.DataTable().ajax.reload();
    });


    $("button.btn-addSendexpress").click(function () {

        $("input[name='ExpressType']", ".modal-import-mail").val(2);
        $(".modal-import-mail").modal({ backdrop: 'static', keyboard: false });
    });

    $("button.btn-submitExpressInfo").click(function () {

        if (!validInput()) {

            alert("You must input phone name and express no");
        }
        else {

            $.ajax({
                url: "/MailSR/SubmitExpressInfo",
                type: 'POST',
                data: $("form", ".modal-import-mail").serialize()
            }).done(function () {

                $(".modal-import-mail").modal("hide");
                expressInfoTable.DataTable().ajax.reload();
            }).fail(function () {

            });
        }

        

    });


}