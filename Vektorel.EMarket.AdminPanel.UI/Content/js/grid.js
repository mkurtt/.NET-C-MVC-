$(document).ready(function () {
    $.ajax({
        url: '/Product/GetProducts',
        type: 'get',
        success: function (response) {
            if (response.status) {
                LoadTable(response.data)
            }
            else {
                alert('Sunucuda hata oluştu.')
            }
        }

    })
})



function LoadTable(data) {
    $("#jsGrid").jsGrid({
        width: "100%",
        height: "400px",

        inserting: true,
        editing: true,
        sorting: true,
        paging: true,

        data: data,

        onItemDeleting: function (args) {
            $.ajax({
                url: '/Product/Delete',
                data: args.item,
                method: 'get',
                success: function (response) {
                    alert(response)
                }
            })


        },

        fields: [
            { name: "Id", type: "text", width: 150, validate: "required" },
            { name: "Name", type: "text", width: 150, validate: "required" },
            { name: "UnitPrice", type: "number", width: 50 },
            { name: "DiscountRate", type: "text", width: 200 },
            //{ name: "Category", type: "select", items: countries, valueField: "Id", textField: "Name" },
            { name: "IsActive", type: "checkbox", title: "Is Product Active?", sorting: true },
            { type: "control" }
        ]
    });
}


