export function CarDetailSkeleton() {
  return (
    <div className="mx-auto max-w-7xl px-6">
      <div className="grid lg:grid-cols-[1.2fr_1fr] gap-12">
        <div className="aspect-[16/10] rounded-xl bg-gray-200 animate-pulse" />
        <div className="space-y-4">
          <div className="h-10 bg-gray-200 rounded w-3/4 animate-pulse" />
          <div className="h-8 bg-gray-200 rounded w-1/3 animate-pulse" />
          <div className="h-4 bg-gray-200 rounded w-full animate-pulse" />
          <div className="h-4 bg-gray-200 rounded w-2/3 animate-pulse" />
          <div className="h-14 bg-gray-200 rounded w-1/3 animate-pulse mt-8" />
        </div>
      </div>
    </div>
  );
}
