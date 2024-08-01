const {test, expect} = require('@playwright/test');

test('user can add a task', async ({page}) =>{

    //arrange
    await page.goto('http://localhost:8080/');
    await page.fill('#task-input', 'Test Task');
    await page.click('#add-task');
    
    //act
    const taskText = await page.textContent('.task');

    //assert
    expect(taskText).toContain('Test Task');
})

test('user can delete a task', async ({page}) =>{

    //arrange
    await page.goto('http://localhost:8080/');
    await page.fill('#task-input', 'Test Task');
    await page.click('#add-task');
    
    //act
    await page.click('.task, .delete-task');

    //assert
    const tasks = await page.$$eval('.task', tasks => tasks.map(
        task => task.textContent
    ))
    expect(tasks).not.toContain('Test Task')
})

    test('user can mark task as completed', async ({page}) =>{

        //arrange
        await page.goto('http://localhost:8080/');
        await page.fill('#task-input', 'Test Task');
        await page.click('#add-task');
        
        //act
        await page.click('.task .task-complete');
    
        //assert
        const completedTask = await page.$('.task.completed')
        expect(completedTask).not.toBeNull()
})

test('user can filter a task', async ({page}) =>{

    //arrange
    await page.goto('http://localhost:8080/');
    await page.fill('#task-input', 'Test Task');
    await page.click('#add-task');
    await page.click('.task, .task-complete');
    
    //act
    await page.selectOption('#filter', "Completed")

    //assert
    const incompleteTasks = await page.$('.task:not(.completed)')
    expect(incompleteTasks).toBeNull()
})
