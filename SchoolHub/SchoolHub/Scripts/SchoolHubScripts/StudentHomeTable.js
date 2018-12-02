$.fn.dataTable.ext.order['dom-checkbox'] = function (settings, col) {
    return this.api().column(col, { order: 'index' }).nodes().map(function (td, i) {
        return $('input', td).prop('checked') ? '1' : '0';
    });
}

$(document).ready(function () {
    var table = $('#example').DataTable({
        "columns": [
            null,
            null,
            null,
            null,
            null,
            { "orderDataType": "dom-checkbox" }
        ],
        responsive: {
            details: {
                display: $.fn.dataTable.Responsive.display.modal({
                    header: function (row) {
                        var data = row.data();
                        return 'Details for class # ' + data[0];
                    }
                }),
                renderer: $.fn.dataTable.Responsive.renderer.tableAll({
                    tableClass: 'table'

                })
            }
        },
        colReorder: true,
    });
});
