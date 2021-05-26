
$(function () {
    var bookManagerJS = new BookManagerJS();
})

class BookManagerJS {
    action = "";
    constructor() {
        this.loadTable();
        this.initEvents();
    }

    initEvents() {
        $("#btnCreate").click(this.btnCreateOnClick.bind(this));
        $("#btnConfirm").click(this.btnConfirmOnClick.bind(this));
        $("#btnEdit").click(this.btnEditOnClick.bind(this));
        $("#btnDelete").click(this.btnDeleteOnClick.bind(this));
    }


    /// EVENT FUNCTION 
    btnDeleteOnClick() {

        // 1. Get row is being selected
        var rowSelected = $(".selected");

        // 2. check valid selected
        if (rowSelected.length < 1) {
            alert("Chưa có đối tượng nào được chọn");
            return;
        }

        // 3. Get bookID
        var bookId = rowSelected.children()[0].textContent;
        var bookName = rowSelected.children()[1].textContent;

        if (confirm("Bạn có chắc chắn xóa " + bookName)) {
            // 4. Call API remove from database
            $.ajax({
                url: "api/book/" + bookId,
                method: "DELETE"
            }).done(function (res) {
                if (res) {
                    // remote row
                    rowSelected.remove();
                } else {
                    alert("Xóa thất bại");
                }
            }).fail(function (res) {
                console.log(res);
            })
        }

    }

    btnCreateOnClick() {
        // 1. change state for getting action confirm
        this.action = "create";
        // 2. clear and show form for input new data
        this.formFilter();
        this.showForm();
    }

    btnEditOnClick() {
        var self = this;
        // 1. change state for getting action confirm
        this.action = "edit";

        // 2. get row is being selected
        var rowSelected = $(".selected");

        // 3. check valid selected
        if (rowSelected.length < 1) {
            alert("Chưa có đối tượng nào được chọn");
            return;
        }

        // 4. get data from server by bookId
        var bookId = rowSelected.children()[0].textContent;
        $.ajax({
            url: "api/book/" + bookId,
            method: "GET"
        }).done(function (res) {

            // 5. show form and fill data
            self.formFilter(res);
            self.showForm();
        }).fail(function (res) {
            alert(res);
        })

    }

    btnConfirmOnClick() {
        var self = this;
        // 1. Get data  from input form
        var bookId = $("#inputBookId").val();
        var name = $("#inputName").val();
        var editor = $("#inputEditor").val();
        var fiction = $("#inputFiction").prop("checked") ? 1 : 0;
        var type = $("#inputType").val();
        var price = $("#inputPrice").val();
        var releaseYear = $("#inputReleaseYear").val();
        var creator = $("#inputCreator").val();

        // 2. Create book object
        var book = {
            BookId: bookId,
            Name: name,
            Editor: editor,
            Fiction: fiction,
            Type: type,
            Price: price,
            Release_Year: releaseYear,
            Creator: creator
        }

        // 3. Check null
        var checkInput = true;
        var keys = Object.keys(book);
        for (var i = 0; i < keys.length; i++) {
            if (keys[i] == "Fiction") continue;
            if (book[keys[i]] == "") {
                checkInput = false;
            }
        }
        if (!checkInput) {
            $("#inputNotice").html("Vui lòng nhập đầy đủ thông tin");
            return;
        }

        // 4. confirm action and resolve data
        if (this.action == "edit") {

            // a. Updata data to server
            $.ajax({
                url: "api/book",
                method: "PUT",
                data: book
            }).done(function (res) {
                if (res) {

                    // b. reload table and hide form
                    self.loadTable();
                    self.hideForm();
                } else {
                    alert("Chỉnh sửa thất bại");
                }
            }).fail(function (res) {
                console.log(res);
            })

        } else {

            // 5.Call AJAX POST, if success then add row and hide form
            $.ajax({
                url: "api/book",
                method: "POST",
                data: book
            }).done(function (res) {
                if (res) {
                    self.addRow(book);
                    self.hideForm();
                } else {
                    alert("Thêm dữ liệu thất bại")
                }

            }).fail(function (res) {
                console.log(res);
            })

        }

    }

    /// UI FUNCTION
    loadTable() {
        var self = this;
        // 1. clear table
        $("#bookTable tbody").html("");

        // 2. AJAX call API to get data
        $.ajax({
            url: 'api/book',
            method: 'GET'
        }).done(function (res) {
            // 3. Render to view
            $.each(res, function (index, item) {
                self.addRow(item);
            })
        }).fail(function (res) {
            alert(res);
        })

    }

    addRow(book) {
        var rowHtml = "<tr id='" + book["BookId"] + "' onclick='rowSelected(this)'>"
            + "<td class='td_bookId'>" + book["BookId"] + "</td>"
            + "<td class='td_name'>" + book["Name"] + "</td>"
            + "<td class='td_editor'>" + book["Editor"] + "</td>"
            + "<td class='td_fiction'>" + (book["Fiction"] == 1 ? true : false) + "</td>"
            + "<td class='td_type'>" + book["Type"] + "</td>"
            + "<td class='td_price'>" + book["Price"] + "</td>"
            + "<td class='td_releaseYear'>" + book["Release_Year"] + "</td>"
            + "<td class='td_creator'>" + book["Creator"] + "</td>"
            + "</tr >";
        $("#bookTable tbody").append(rowHtml);
    }

    showForm() {
        if (this.action == 'edit') {
            // Disable edit ID when edit
            $("#inputBookId").attr("disabled", true);
        } else {
            // Enable edit ID for create
            $("#inputBookId").attr("disabled", false);
        }
        $(".modal").modal("show");
    }

    hideForm() {
        $(".modal").modal("hide");
    }

    formFilter(book = {
        BookId: "",
        Name: "",
        Editor: "",
        Fiction: false,
        Type: "",
        Price: "",
        ReleaseYear: "",
        Creator: "ADMIN"
    }) {
        $("#inputBookId").val(book["BookId"]);
        $("#inputName").val(book["Name"]);
        $("#inputEditor").val(book["Editor"]);
        $("#inputFiction").prop("checked", book["Fiction"]);
        $("#inputType").val(book["Type"]);
        $("#inputPrice").val(book["Price"]);
        $("#inputReleaseYear").val(book["Release_Year"]);
        $("#inputCreator").val(book["Creator"]);
    }
}

// COMMON ENTITY
function rowSelected(element) {
    $(element).addClass('selected bg-secondary').siblings().removeClass('selected bg-secondary');
}

//var books = [
//    {
//        BookId: "B0001",
//        Name: "Tây Du Ký",
//        Editor: "Ngô Thừa Ân",
//        Fiction: true,
//        Type: "Thần thoại",
//        Price: 100000,
//        ReleaseYear: 1980,
//        Creator: "ADMIN"
//    },
//    {
//        BookId: "B0002",
//        Name: "Tôi Tự Học",
//        Editor: "Nguyễn Duy Cần",
//        Fiction: false,
//        Type: "Lý luận xã hội",
//        Price: 100000,
//        ReleaseYear: 1910,
//        Creator: "ADMIN"
//    },
//    {
//        BookId: "B0003",
//        Name: "Tây Du Ký",
//        Editor: "Ngô Thừa Ân",
//        Fiction: true,
//        Type: "Thần thoại",
//        Price: 100000,
//        ReleaseYear: 1980,
//        Creator: "ADMIN"
//    }
//]