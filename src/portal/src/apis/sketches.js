const getSketches=(category)=>{

    const data = [
        {
            title:'Singleton',
            description:'Singleton Pattern',
            tags:['Design Pattern','Gang Of Four']
        },
        {
            title:'Adapter',
            description:'Singleton Pattern',
            tags:['Design Pattern','Gang Of Four']
        },
        {
            title:'Async Await',
            description:'Async Await',
            tags:['DotNet']
        }
    ];

    const result = data.filter((item)=>item.tags.includes(category));
    return result;
}



const getTags = () => {
    return [
        'Design Pattern',
        'Gang Of Four',
        'DotNet'
    ]
}

export {getSketches, getTags}