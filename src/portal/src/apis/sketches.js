import axios from "axios";

const getSketches= async (tagId)=>{
    var apiPath = process.env.VUE_APP_API_ENDPOINT + process.env.VUE_APP_API_ENTRIES;
    const response = await axios.get(apiPath,{params:{
        id:tagId
    }});
    console.log(response)
    const result = response.data;
    return result;
}



const getTags = async () => {
    
    var apiPath = process.env.VUE_APP_API_ENDPOINT + process.env.VUE_APP_API_TAGS;
    const response = await axios.get(apiPath);
    console.log(response)
    const result = response.data;
    return result;
}

export {getSketches, getTags}