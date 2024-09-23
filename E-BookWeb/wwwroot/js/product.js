﻿var dataTable;

$(document).ready(function () {
    loadDataTable();
});
function loadDataTable() {
    
    dataTable = $('#myTable').DataTable({
        "ajax": { "url": "/Admin/Product/GetAll" },
        "columns": [
            { "data": "tital", "width": "15%" },
            { "data": "isbn", "width": "15%" },
            { "data": "price", "width": "15%" },
            { "data": "catogery.name", "width": "15%" },
            { "data": "listPrice", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
 
 
						<a href="/Admin/Product/Upsert?id=${data}"  class="btn btn-primary mx-2">
							<i class="bi bi-pencil-square"></i> Edit</a>

							<a  onclick=Delete('/Admin/Product/Delete/'+${data})
                               class="btn btn-danger mx-2">
								<i class="bi bi-trash3"></i> Delete
							</a>
						 `
                },
                "width": "20%"
            },

        ]
    })
}
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
                if (data.success) {
                        dataTable.ajax.reload();
                    toastr.success(data.message)
                     
                    } else {
                    toastr.error(data.message)
                     

                    }
                },
                error: function (error) {
                    alert("error")
                }
            })
            
        }
    });
}