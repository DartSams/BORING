using Microsoft.EntityFrameworkCore;
using RazorPagesUI.Data;

public class SurveyDbContext : DbContext
{
    public SurveyDbContext(DbContextOptions<SurveyDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserRight>()
            .HasKey(ur => new { ur.UserId, ur.RightId });

        // Configure relationships between UserRight, User, and Right
        modelBuilder.Entity<UserRight>()
            .HasOne(ur => ur.User)
            .WithMany(u => u.UserRights)
            .HasForeignKey(ur => ur.UserId);

        modelBuilder.Entity<UserRight>()
            .HasOne(ur => ur.Right)
            .WithMany(u => u.UserRights)
            .HasForeignKey(ur => ur.RightId);

        modelBuilder.Entity<CampaignAssignment>()
            .HasIndex(ca => new { ca.UserId, ca.CampaignId })
            .IsUnique();

        modelBuilder.Entity<CampaignAssignment>()
            .HasOne(ca => ca.User)
            .WithMany(u => u.CampaignAssignments)
            .HasForeignKey(ca => ca.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<CampaignAssignment>()
            .HasOne(ca => ca.Campaign)
            .WithMany(c => c.CampaignAssignments)
            .HasForeignKey(ca => ca.CampaignId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<CampaignAssignment>()
            .HasOne(ca => ca.AssignedBy)
            .WithMany()
            .HasForeignKey(ca => ca.AssignedById)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<CampaignAssignment>()
            .HasOne(ca => ca.DeactivatedBy)
            .WithMany()
            .HasForeignKey(ca => ca.DeactivatedById)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<SurveyAnswer>()
            .HasKey(sa => new { sa.SurveyId, sa.AnswerTemplateId });

        modelBuilder.Entity<SurveyAnswer>()
            .HasOne(sa => sa.Survey)
            .WithMany(s => s.Answers)
            .HasForeignKey(sa => sa.SurveyId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<SurveyAnswer>()
            .HasOne(sa => sa.AnswerTemplate)
            .WithMany(at => at.SurveyAnswers)
            .HasForeignKey(sa => sa.AnswerTemplateId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Question>()
            .HasMany(q => q.AnswerTemplates)
            .WithOne(at => at.Question)
            .HasForeignKey(at => at.QuestionId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Question>()
            .HasOne(q => q.FollowsAnswer)
            .WithMany()
            .HasForeignKey(q => q.FollowsAnswerId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<AnswerTemplate>()
            .HasOne(at => at.Question)
            .WithMany(q => q.AnswerTemplates)
            .HasForeignKey(at => at.QuestionId)
            .OnDelete(DeleteBehavior.Restrict);

        // Populate test data
        modelBuilder.Entity<Right>().HasData(
            new Right { Id = 1, Name = "Admin" },
            new Right { Id = 2, Name = "Create Campaign" },
            new Right { Id = 3, Name = "Assign Campaign" },
            new Right { Id = 4, Name = "Distribute Campaign" }
        );

        modelBuilder.Entity<Institution>().HasData(
            new Institution { Id = new Guid("11111111-1111-1111-1111-111111111111"), Name = "Georgia Southern University" },
            new Institution { Id = new Guid("22222222-2222-2222-2222-222222222222"), Name = "Savannah College of Art and Design" },
            new Institution { Id = new Guid("33333333-3333-3333-3333-333333333333"), Name = "Georgia State University" },
            new Institution { Id = new Guid("44444444-4444-4444-4444-444444444444"), Name = "University of Georgia" },
            new Institution { Id = new Guid("55555555-5555-5555-5555-555555555555"), Name = "Emory University" }
        );

        modelBuilder.Entity<User>().HasData(
            new User { Id = new Guid("11111111-1111-1111-1111-111111111111"), Name = "Eric Landers", EMail = "eric.landers@fake_email.com", InstitutionId = new Guid("11111111-1111-1111-1111-111111111111") },
            new User { Id = new Guid("22222222-2222-2222-2222-222222222222"), Name = "GSU One", EMail = "gsu.one@fake_email.com", InstitutionId = new Guid("11111111-1111-1111-1111-111111111111") },
            new User { Id = new Guid("33333333-3333-3333-3333-333333333333"), Name = "GSU 2", EMail = "gsu.2@fake_email.com", InstitutionId = new Guid("11111111-1111-1111-1111-111111111111") },
            new User { Id = new Guid("44444444-4444-4444-4444-444444444444"), Name = "SCAD 1", EMail = "scad.1@fake_email.com", InstitutionId = new Guid("22222222-2222-2222-2222-222222222222") },
            new User { Id = new Guid("55555555-5555-5555-5555-555555555555"), Name = "SCAD 2", EMail = "scad.2@fake_email.com", InstitutionId = new Guid("22222222-2222-2222-2222-222222222222") },
            new User { Id = new Guid("66666666-6666-6666-6666-666666666666"), Name = "GAState 1", EMail = "gastate.1@fake_email.com", InstitutionId = new Guid("33333333-3333-3333-3333-333333333333") },
            new User { Id = new Guid("77777777-7777-7777-7777-777777777777"), Name = "GAState 2", EMail = "gastate.2@fake_email.com", InstitutionId = new Guid("33333333-3333-3333-3333-333333333333") },
            new User { Id = new Guid("88888888-8888-8888-8888-888888888888"), Name = "UGA 1", EMail = "uga.1@fake_email.com", InstitutionId = new Guid("44444444-4444-4444-4444-444444444444") },
            new User { Id = new Guid("99999999-9999-9999-9999-999999999999"), Name = "UGA 2", EMail = "uga.2@fake_email.com", InstitutionId = new Guid("44444444-4444-4444-4444-444444444444") },
            new User { Id = new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), Name = "EU 1", EMail = "eu.1@fake_email.com", InstitutionId = new Guid("55555555-5555-5555-5555-555555555555") },
            new User { Id = new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), Name = "EU 2", EMail = "eu.2@fake_email.com", InstitutionId = new Guid("55555555-5555-5555-5555-555555555555") }
        );

        modelBuilder.Entity<UserRight>().HasData(
            // Assign all rights to the first user (Eric Landers)
            new UserRight {UserId = new Guid("11111111-1111-1111-1111-111111111111"), RightId = 1 },
            new UserRight {UserId = new Guid("11111111-1111-1111-1111-111111111111"), RightId = 2 },
            new UserRight {UserId = new Guid("11111111-1111-1111-1111-111111111111"), RightId = 3 },
 
            // Assign "Assign Campaign" right to users belonging to "Georgia Southern University"
            new UserRight {UserId = new Guid("22222222-2222-2222-2222-222222222222"), RightId = 3 },
            new UserRight {UserId = new Guid("33333333-3333-3333-3333-333333333333"), RightId = 3 },

            // Assign "Distribute Campaign" right to all users
            new UserRight {UserId = new Guid("11111111-1111-1111-1111-111111111111"), RightId = 4 },
            new UserRight {UserId = new Guid("22222222-2222-2222-2222-222222222222"), RightId = 4 },
            new UserRight {UserId = new Guid("33333333-3333-3333-3333-333333333333"), RightId = 4 },
            new UserRight {UserId = new Guid("44444444-4444-4444-4444-444444444444"), RightId = 4 },
            new UserRight {UserId = new Guid("55555555-5555-5555-5555-555555555555"), RightId = 4 },
            new UserRight {UserId = new Guid("66666666-6666-6666-6666-666666666666"), RightId = 4 },
            new UserRight {UserId = new Guid("77777777-7777-7777-7777-777777777777"), RightId = 4 },
            new UserRight {UserId = new Guid("88888888-8888-8888-8888-888888888888"), RightId = 4 },
            new UserRight {UserId = new Guid("99999999-9999-9999-9999-999999999999"), RightId = 4 },
            new UserRight {UserId = new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), RightId = 4 },
            new UserRight {UserId = new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), RightId = 4 }
        );


    }
    public DbSet<RazorPagesUI.Data.Institution> Institution { get; set; } = default!;
    public DbSet<RazorPagesUI.Data.Right> Right { get; set; } = default!;
    public DbSet<RazorPagesUI.Data.User> User { get; set; } = default!;
    public DbSet<RazorPagesUI.Data.UserRight> UserRight { get; set; } = default!;
    public DbSet<RazorPagesUI.Data.Campaign> Campaign { get; set; } = default!;
    public DbSet<RazorPagesUI.Data.CampaignAssignment> CampaignAssignment { get; set; } = default!;
    public DbSet<RazorPagesUI.Data.AnswerTemplate> AnswerTemplate { get; set; } = default!;
    public DbSet<RazorPagesUI.Data.Question> Question { get; set; } = default!;
    public DbSet<RazorPagesUI.Data.Survey> Survey { get; set; } = default!;
    public DbSet<RazorPagesUI.Data.SurveyAnswer> SurveyAnswer { get; set; } = default!;
}

