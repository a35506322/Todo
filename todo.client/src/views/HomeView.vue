<script setup>
import { ref, onMounted } from 'vue';
import { initFlowbite } from 'flowbite';

const msg = ref('hello world');

// initialize components based on data attribute selectors
onMounted(() => {
  initFlowbite();
});
</script>

<template>
  <div class="min-h-screen flex items-center justify-center">
    <div class="container mx-auto px-4">
      <div class="grid grid-cols-5 gap-4">
        <div class="col-span-2">
          <div
            class="w-full max-w-sm p-4 bg-white border border-gray-200 rounded-lg shadow sm:p-6 md:p-8"
          >
            <div class="space-y-6">
              <h5 class="text-xl font-medium text-gray-900">請填寫代辦事項</h5>
              <div>
                <label for="name" class="block mb-2 text-sm font-medium text-gray-900">姓名</label>
                <input type="text" name="name" id="name" class="input-success" required />
              </div>
              <div>
                <label for="title" class="block mb-2 text-sm font-medium text-gray-900"
                  >代辦標題</label
                >
                <input type="text" name="name" id="name" class="input-success" required />
              </div>
              <div>
                <label for="title-content" class="block mb-2 text-sm font-medium text-gray-900"
                  >代辦內容</label
                >
                <textarea
                  id="title-content"
                  name="title-content"
                  rows="3"
                  class="textarea-success"
                  required
                ></textarea>
              </div>
              <button type="submit" class="btn-success btn-medium w-full">儲存</button>
            </div>
          </div>
        </div>
        <div class="col-span-3">
          <div id="alert-additional-content-3" class="alert-success" role="alert">
            <div class="flex items-center">
              <svg
                class="w-[16px] h-[16px] me-2"
                aria-hidden="true"
                xmlns="http://www.w3.org/2000/svg"
                width="24"
                height="24"
                fill="currentColor"
                viewBox="0 0 24 24"
              >
                <path
                  fill-rule="evenodd"
                  d="M2 12C2 6.477 6.477 2 12 2s10 4.477 10 10-4.477 10-10 10S2 17.523 2 12Zm13.707-1.293a1 1 0 0 0-1.414-1.414L11 12.586l-1.793-1.793a1 1 0 0 0-1.414 1.414l2.5 2.5a1 1 0 0 0 1.414 0l4-4Z"
                  clip-rule="evenodd"
                />
              </svg>

              <span class="sr-only">Complete</span>
              <h3 class="text-lg font-medium">莊理竣 / 1900吃飯</h3>
              <h3 class="ml-auto text-lg font-medium">已完成 | 2024/04/05 17:00</h3>
            </div>
            <div class="mt-2 mb-4 text-sm">與朋友去吃好吃的</div>
            <div class="flex justify-end">
              <button
                type="button"
                class="btn-outline-success btn-small"
                data-dismiss-target="#alert-additional-content-3"
                aria-label="Close"
              >
                刪除
              </button>
            </div>
          </div>
          <div id="alert-additional-content-5" class="alert-second" role="alert">
            <div class="flex items-center">
              <svg
                class="w-[16px] h-[16px] text-gray-800 dark:text-white me-2"
                aria-hidden="true"
                xmlns="http://www.w3.org/2000/svg"
                width="24"
                height="24"
                fill="currentColor"
                viewBox="0 0 24 24"
              >
                <path
                  fill-rule="evenodd"
                  d="M2 12C2 6.477 6.477 2 12 2s10 4.477 10 10-4.477 10-10 10S2 17.523 2 12Zm9.408-5.5a1 1 0 1 0 0 2h.01a1 1 0 1 0 0-2h-.01ZM10 10a1 1 0 1 0 0 2h1v3h-1a1 1 0 1 0 0 2h4a1 1 0 1 0 0-2h-1v-4a1 1 0 0 0-1-1h-2Z"
                  clip-rule="evenodd"
                />
              </svg>

              <span class="sr-only">Not Complete</span>
              <h3 class="text-lg font-medium">莊理竣 / 1900吃飯</h3>
              <h3 class="ml-auto text-lg font-medium">未完成</h3>
            </div>
            <div class="mt-2 mb-4 text-sm">星期日要去吃飯</div>
            <div class="flex justify-end">
              <button type="button" class="btn-second btn-small inline-flex items-center mr-2">
                完成
              </button>
              <button
                type="button"
                class="btn-outline-second btn-small"
                data-dismiss-target="#alert-additional-content-5"
                aria-label="Close"
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
