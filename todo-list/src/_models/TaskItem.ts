export interface TaskItem{
    id: number;
    title: string;
    due_date: Date;
    priority_id: number;
    is_completed: boolean;
    created_at: number;
}