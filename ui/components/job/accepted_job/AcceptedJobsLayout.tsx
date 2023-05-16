import { useState } from "react";
import { useJobs } from "@/hooks";
import { JobStatus } from "@/enums";
import AcceptedJob from "@/components/job/accepted_job/AcceptedJob";
import InfiniteScroll from 'react-infinite-scroll-component';

export default function AcceptedJobsLayout() {
    const [status] = useState<JobStatus>(JobStatus.accepted);

    const {
        data,
        fetchNextPage,
        hasNextPage,
        isLoading,
        isError,
        error
    } = useJobs(10, status);

    if (isLoading) {
        return <div className="info-text">Loading...</div>;
    }

    if (isError && error) {
        return <div className="info-text">Error: Something went wrong!</div>;
    }

    return (
        <InfiniteScroll
            dataLength={data ? data.pages.reduce((acc, page) => acc + page.jobs.length, 0) : 0}
            next={fetchNextPage}
            hasMore={hasNextPage || false}
            loader={<div className="info-text">Loading...</div>}
            endMessage={<i/>}
        >
            {data &&
                data.pages.map((page) =>
                    page.jobs.map((job) => <AcceptedJob key={job.id} job={job} />)
                )}
        </InfiniteScroll>
    );
}