<script setup lang="ts">
import { onMounted, type Ref, ref } from 'vue';
import axios, { type AxiosResponse } from 'axios';

interface WorkItem {
    id: string;
    title: string;
    description: string;
    status: number;
    createdAt: string;
}

const workItems: Ref<WorkItem[]> = ref([]);

onMounted(async () => {
    await axios.get('http://localhost:5119/api/WorkItem').then((res: AxiosResponse) => {
        workItems.value = res.data;
    });
});
</script>

<script lang="ts">
const dateToReadableString = (dateStr: string) => {
    const date = new Date(dateStr);

    const day = new Intl.DateTimeFormat('en', { day: '2-digit' }).format(date);
    const month = new Intl.DateTimeFormat('en', { month: '2-digit' }).format(date);
    const year = new Intl.DateTimeFormat('en', { year: 'numeric' }).format(date);

    return `${day}/${month}/${year}`;
};

const statusNumToDescriptor = (status: number) => {
    enum Status {
        New = 'New',
        Proposed = 'Proposed',
        Active = 'Active',
        InDevelopment = 'In Development',
        Developed = 'Developed',
        Review = 'Review',
        InTest = 'In Test',
        Tested = 'Tested',
        Closed = 'Closed',
    }

    const statusArray = Object.values(Status);
    return statusArray[status];
};
</script>

<template>
    <div>
        <div v-for="item in workItems" :key="item.id" class="card m-2" style="width: 18rem">
            <div class="card-body">
                <h5 class="card-title fw-bold">{{ item.title }}</h5>
                <p class="card-text flex flex-row">
                    {{ item.description }}<br />
                    {{ statusNumToDescriptor(item.status) }}<br />
                    {{ dateToReadableString(item.createdAt) }}
                </p>
            </div>
        </div>
    </div>
</template>
