
var dataTable;
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/product/getall' },
        "columns": [
            { data: 'title', "width": "18%" },
            { data: 'isbn', "width": "10%" },
            { data: 'author', "width": "10%" },
            { data: 'listPrice', "width": "5%" },
            { data: 'category.name', "width": "15%" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="btn-group" role="group">
                        <a href="/admin/product/create_update?id=${data}" class="btn btn-outline-primary btn-sm">
                            <i class="bi bi-pencil-square"></i> Edit
                        </a>
                        <a onClick=Delete('/admin/product/delete/${data}') class="btn btn-outline-danger btn-sm ms-2 delete-btn" data-id="${data}">
                            <i class="bi bi-trash3-fill"></i> Delete
                        </a>
                    </div>`;
                },
                "width": "15%"
            }
        ]
    });
}

$(document).on('click', '.delete-btn', function () {
    var url = '/admin/product/delete/' + $(this).data('id');
    Delete(url);
});

function Delete(url) {
    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    console.log(data); 
                    dataTable.ajax.reload();

                    if (data && data.message) {
                        toastr.success(data.message);
                    } else {
                        toastr.error('An error occurred.');
                    }
                }
            });
        }
    });
}
