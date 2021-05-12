
export async function GetFiles() {
    const handles = await window.showOpenFilePicker({
        startIn: 'music',
        multiple: true,
        types: [
            {
                description: 'Music Files',
                accept: {
                    'audio/mp3': ['.mp3'],
                },
            },
        ],
    });
    /**
     * @type {File[]}
     */
    const files = await Promise.all(handles?.map(async handle => {
        const file = await handle.getFile();
        file.handle = handle;
        return file;
    }) ?? []);

    console.log(files);
    return files;
}