<script setup>
import { ref, onMounted } from 'vue';
import { initFlowbite } from 'flowbite';
import { todoService } from '@/services/todoServices';
import moment from 'moment';
import { returnCodeEnum } from '@/utils/enums';

const todos = ref([]);
const getTodo = async () => {
  const result = await todoService.getTodo();
  const { returnData } = result.data;
  todos.value = [...returnData];
};

const request = ref({
  name: '',
  title: '',
  todoContent: ''
});

const initRequest = () => {
  isInsertStatus.value = {
    isInsert: true,
    todoId: ''
  };
  request.value = {
    name: '',
    title: '',
    todoContent: ''
  };
};

const isInsertStatus = ref({
  isInsert: true,
  todoId: ''
});

const currentRequest = (value) => {
  isInsertStatus.value = {
    isInsert: false,
    todoId: value.todoId
  };
  request.value = {
    name: value.name,
    title: value.title,
    todoContent: value.todoContent
  };
};

const onComplete = async (todo) => {
  try {
    const result = await todoService.updateTodoStatus(todo.todoId, {
      todoId: todo.todoId,
      isComplete: 'Y'
    });
    const { returnCode, returnMessage } = result.data;

    switch (returnCode) {
      case returnCodeEnum.success:
        await getTodo();
        break;
      default:
        alert(returnMessage);
        break;
    }
  } catch (error) {
    console.error('onSubmit', error);
    alert('意外狀況');
  }
};

const onDelete = async (todo) => {
  try {
    const result = await todoService.deleteTodo(todo.todoId);
    const { returnCode, returnMessage } = result.data;

    switch (returnCode) {
      case returnCodeEnum.success:
        await getTodo();
        break;
      default:
        alert(returnMessage);
        break;
    }
  } catch (error) {
    console.error('onSubmit', error);
    alert('意外狀況');
  }
};

const onSubmit = async () => {
  try {
    let result;
    if (isInsertStatus.value.isInsert) {
      result = await todoService.insertTodo(request.value);
    } else {
      const todoId = isInsertStatus.value.todoId;
      result = await todoService.updateTodoContent(todoId, { todoId: todoId, ...request.value });
    }

    const { returnCode, returnMessage } = result.data;

    switch (returnCode) {
      case returnCodeEnum.success:
        await getTodo();
        initRequest();
        break;
      default:
        alert(returnMessage);
        break;
    }
  } catch (error) {
    console.error('onSubmit', error);
  }
};

// initialize components based on data attribute selectors
onMounted(async () => {
  await getTodo();
  initFlowbite();
});
</script>

<template>
  <div class="min-h-screen flex items-center justify-center">
    <div class="container mx-auto px-4">
      <div class="grid grid-cols-5 gap-4">
        <div class="col-span-2">
          <form
            class="w-full max-w-sm p-4 bg-white border border-gray-200 rounded-lg shadow sm:p-6 md:p-8"
            @submit.prevent="onSubmit"
          >
            <div class="space-y-6">
              <h5 class="text-xl font-medium text-gray-900">請填寫代辦事項</h5>
              <div>
                <label for="name" class="block mb-2 text-sm font-medium text-gray-900">姓名</label>
                <input
                  type="text"
                  name="name"
                  id="name"
                  class="input-success"
                  v-model="request.name"
                />
              </div>
              <div>
                <label for="title" class="block mb-2 text-sm font-medium text-gray-900"
                  >代辦標題</label
                >
                <input
                  type="text"
                  name="title"
                  id="title"
                  class="input-success"
                  v-model="request.title"
                />
              </div>
              <div>
                <label for="todo-content" class="block mb-2 text-sm font-medium text-gray-900"
                  >代辦內容</label
                >
                <textarea
                  id="todo-content"
                  name="todo-content"
                  rows="3"
                  class="textarea-success"
                  v-model="request.todoContent"
                ></textarea>
              </div>
              <button type="submit" class="btn-success btn-medium w-full">儲存</button>
            </div>
          </form>
        </div>
        <div class="col-span-3">
          <div
            :id="`alert-additional-content-${index}`"
            :class="[todo.isComplete === 'Y' ? 'alert-success' : 'alert-second']"
            role="alert"
            v-for="(todo, index) in todos"
            :key="todo.todoId"
            class="mb-3"
          >
            <div class="flex items-center">
              <svg
                class="w-[24px] h-[24px] me-2"
                aria-hidden="true"
                xmlns="http://www.w3.org/2000/svg"
                width="24"
                height="24"
                fill="currentColor"
                viewBox="0 0 24 24"
              >
                <path
                  v-if="todo.isComplete === 'Y'"
                  fill-rule="evenodd"
                  d="M2 12C2 6.477 6.477 2 12 2s10 4.477 10 10-4.477 10-10 10S2 17.523 2 12Zm13.707-1.293a1 1 0 0 0-1.414-1.414L11 12.586l-1.793-1.793a1 1 0 0 0-1.414 1.414l2.5 2.5a1 1 0 0 0 1.414 0l4-4Z"
                  clip-rule="evenodd"
                />
                <path
                  v-else
                  fill-rule="evenodd"
                  d="M2 12C2 6.477 6.477 2 12 2s10 4.477 10 10-4.477 10-10 10S2 17.523 2 12Zm9.408-5.5a1 1 0 1 0 0 2h.01a1 1 0 1 0 0-2h-.01ZM10 10a1 1 0 1 0 0 2h1v3h-1a1 1 0 1 0 0 2h4a1 1 0 1 0 0-2h-1v-4a1 1 0 0 0-1-1h-2Z"
                  clip-rule="evenodd"
                />
              </svg>

              <span class="sr-only">
                {{ todo.isComplete === 'Y' ? 'Complete' : 'Not Complete' }}
              </span>
              <h3 class="text-lg font-medium">{{ todo.name }}/ {{ todo.title }}</h3>
              <h3 class="ml-auto text-lg font-medium">
                {{ todo.isComplete === 'Y' ? '已完成' : '未完成' }}
                {{
                  todo.completeTime
                    ? `| ${moment(todo.completeTime).format('YYYY/MM/DD HH:mm:ss')}`
                    : ''
                }}
              </h3>
            </div>
            <div class="mt-2 mb-4 text-sm">{{ todo.todoContent }}</div>
            <div class="flex justify-end">
              <button
                type="button"
                class="btn-second btn-small inline-flex items-center mr-2"
                v-if="todo.isComplete === 'N'"
                @click="onComplete(todo)"
              >
                完成
              </button>
              <button
                type="button"
                class="btn-small inline-flex items-center mr-2"
                :class="[todo.isComplete === 'Y' ? 'btn-success' : 'btn-second']"
                @click="currentRequest(todo)"
              >
                編輯
              </button>
              <button
                type="button"
                class="btn-small"
                :class="[todo.isComplete === 'Y' ? 'btn-outline-success' : 'btn-outline-second']"
                :data-dismiss-target="`#alert-additional-content-${index}`"
                aria-label="Close"
                @click="onDelete(todo)"
              >
                刪除
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<style scoped></style>
