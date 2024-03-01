function run(){
    // read();
    // edit("b857368c-3a30-41ea-a101-acda9eb2fb1f");
    // create("title", "author", "content");
    // destroy("4ce7a607-ae9a-41dd-8237-66ef022591d3");
    // update("c9d27196-531a-43a8-8345-54298728dcc8", "heloo", "eheee", "thsi is ehe;x");
}

function read(){
    let lstBlogs = getblogs();

    for(let i = 0 ; i < lstBlogs.length ; i++){
        const item = lstBlogs[i];
        console.log(item.title);
        console.log(item.author);
        console.log(item.content);
    }
}

function edit (id){
    let lstBlogs = getblogs();

    const items =  lstBlogs.filter(x => x.id === id)

    if(items.length <= 0){
        console.log("no item found");
        return;
    }
    
    const item = items[0];
    console.log(item)
}

function create(title, author, content){

    let lstBlogs = getblogs();

   const blog = {
        id : uuidv4(),
        title : title,
        author : author,
        content : content,
   }

   lstBlogs.push(blog);
   setBlogs(lstBlogs);
}

function update(id, title , author, content){
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

   console.log(blog)

    lstBlogs[itemIndex] = blog;

    setBlogs(lstBlogs);
}

function destroy(id){
    let lstBlogs = getblogs();

    const removedBlogs = lstBlogs.filter(x => x.id !== id);
    setBlogs(removedBlogs);;
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

run();