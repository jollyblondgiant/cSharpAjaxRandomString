// Write your Javascript code.
$(()=>{
    console.log("RELOADED DUMBASS")
    $("button").click(()=>{
        $.ajax({
            type: "GET",
            url: "generate"

        })
        .done((res)=>{
            $("#newCode").html(res.code)
            $("#codeCount").html(res.count)
        })
    })
})