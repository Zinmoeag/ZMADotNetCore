let _blogId = null;


function run(){
    read();
    // edit("b857368c-3a30-41ea-a101-acda9eb2fb1f");
    // create("title", "author", "content");
    // destroy("4ce7a607-ae9a-41dd-8237-66ef022591d3");
    // update("c9d27196-531a-43a8-8345-54298728dcc8", "heloo", "eheee", "thsi is ehe;x");
}

function generateBlogDatas (count){
    for(let i = 1; i <= count; i++){
        create(`title-${i}`, `author-${i}`, `content-${i}`);
    }
}
// generateBlogDatas(100);

function successMessage(message){
    Notiflix.Notify.success(message);
}

function read(){
    console.log("thisis read")
    if ( $.fn.DataTable.isDataTable('#datatable') ) {
        $('#datatable').DataTable().destroy();
    }

    let lstBlogs = getblogs();
    $("#table_data").html("");

    let htmlrow = "";

    for(let i = 0 ; i < lstBlogs.length ; i++){
        const item = lstBlogs[i];
        console.log(item.title);
        console.log(item.author);
        console.log(item.content);

        htmlrow += `
            <tr>
                <td>
                    <button type="button" class="btn btn-primary" onclick="edit('${item.id}')">edit</button>
                    <button type="button" class="btn btn-danger" onclick="destroy('${item.id}')">delete</button>
                </td>
                <td>${item.title}</td>
                <td>${item.author}</td>
                <td>${item.content}</td>
            </tr>
        `
    }

    $("#table_data").html(htmlrow);
    new DataTable('#datatable');
}

function edit (id){
    let lstBlogs = getblogs();

    const items =  lstBlogs.filter(x => x.id === id)

    if(items.length <= 0){
        console.log("no item found");
        return;
    }
    
    const item = items[0];
    
    $("#title").val(item.title);
    $("#author").val(item.author);
    $("#content").val(item.content);

    _blogId = item.id;
}

function create(title, author, content){

    Notiflix.Loading.circle();

    setTimeout(() => {
        let lstBlogs = getblogs();
    
       const blog = {
            id : uuidv4(),
            title : title,
            author : author,
            content : content,
       }
    
       lstBlogs.push(blog);
       setBlogs(lstBlogs);

       Notiflix.Loading.remove();
       successMessage("Blog have been saved Successfully")
    }, 3000);

}

function update(id, title , author, content){

    Notiflix.Loading.circle();

    setTimeout(() => {
        
        let lstBlogs = getblogs();
    
        let itemIndex = lstBlogs.findIndex( x => x.id === id);
    
        if(itemIndex < 0){
            console.log("no item fund")
            return;
        }
    
        const blog = {
            id : lstBlogs[itemIndex].id,
            title : title,
            author : author,
            content : content,
       }
    
        lstBlogs[itemIndex] = blog;
    
        setBlogs(lstBlogs);
        Notiflix.Loading.remove();

        _blogId = null;
        successMessage("successfullly updated")

    }, 3000);
}

run();

function destroy(id){

    // Swal.fire({
    //     title: "Are you sure?",
    //     text: "You won't be able to revert this!",
    //     icon: "question",
    //     showCancelButton: true,
    //     confirmButtonColor: "#3085d6",
    //     cancelButtonColor: "#d33",
    //     confirmButtonText: "Yes, delete it!"
    //   }).then((result) => {
    //     if (result.isConfirmed) {
    //         deleteBlog();

    //         successMessage("deleted")
    //     }
    //   });

    Notiflix.Confirm.show(
        'Are You sure about that',
        'Do you agree with me?',
        'Yes',
        'No',
        function okCb() {
            deleteBlog(id);
            successMessage("successfully")
        },
        function cancelCb() {
        },
        {
        },
        );
}

function deleteBlog(id){
    let lstBlogs = getblogs();

    const removedBlogs = lstBlogs.filter(x => x.id !== id);
    setBlogs(removedBlogs);
    read();
}

function uuidv4() {
    return "10000000-1000-4000-8000-100000000000".replace(/[018]/g, c =>
      (c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> c / 4).toString(16)
    );
}
 
function getblogs (){
    let lstBlogs = [];

    const blogStr = localStorage.getItem('tbl_blogs');

   if(blogStr){
     lstBlogs = JSON.parse(blogStr);
   }

   return lstBlogs;

}

function setBlogs(blogs){
    const jsonblogs = JSON.stringify(blogs);

   localStorage.setItem("tbl_blogs", jsonblogs);

}

$("#save_btn").click(() => {
    const title = $("#title").val();
    const author = $("#author").val();
    const content = $("#content").val();

    if(_blogId){
        update(_blogId, title, author, content);
    }else{
        create(title, author, content)
    }

    $("#title").val("");
    $("#author").val("");
    $("#content").val("");

    $("#title").focus();

    read();
})