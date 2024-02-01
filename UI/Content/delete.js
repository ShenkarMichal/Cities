/// <reference path="jquery.js" />

let URL = ""
let ID  = 0

function AskQuestion(url, id) {
    console.log(url, id)
    URL = url,
    ID = id
}

function deleteCity() {
    return new Promise((resolve, reject) => {
        $.ajax({
            url: URL + ID,
            type: "POST",
            success: (result) => {
                console.log(URL, ID)
                $("#a_" + ID).fadeOut()
                $("#deleteModal").modal("hide");
            },
            error: err => console.log(err)
        })
    })

}




